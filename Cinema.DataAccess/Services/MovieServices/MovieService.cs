﻿using Cinema.DataAccess.Context;
using Cinema.DataAccess.Services.RepositoryServices;
using Cinema.Models.Models;
using Cinema.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cinema.DataAccess.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDBContext _context;

        public MovieService(CinemaDBContext context) 
        {
            _context = context;
        }

        // Movies
        public async Task<MovieDTO> GetAsync(int movieID)
        {
            var movie = await _context.Movies
                 .Where(m => m.ID == movieID)
                 .Select(m => new MovieDTO()
                 {
                     ID = m.ID,
                     Name = m.Name,
                     AgeRating = m.AgeRating,
                     Duration = m.Duration,
                     Trailer = m.Trailer,
                     Description = m.Description,
                     ReleaseDate = m.ReleaseDate,
                     Screenings = (_context.Screenings
                            .Where(s => s.MovieID == m.ID)
                            .Select(s => new ScreeningDTO()
                            {
                                ID = s.ID,
                                DateTime = s.DateTime,
                                MovieID = s.MovieID,
                                RoomID = s.RoomID
                            })
                            .OrderBy(s => s.DateTime)
                            .ToList()
                    ),
                 })
                 .FirstOrDefaultAsync();

            // UGGGGHH I need to filter out the seats 

            foreach (var screening in movie.Screenings)
            {
                var seats = await _context.SeatScreenings
                    .Where(ss => ss.ScreeningID == screening.ID)
                    .Select(s => new SeatScreeningDTO()
                    {
                        ScreeningID = s.ScreeningID,
                        Booked = s.Booked,
                    })
                    .ToListAsync();

                seats.Where(s => s.Booked != true);

                Console.WriteLine(seats.Count);
            }

            return movie;
        }

        public async Task<List<MovieDTO>> GetAllAsync()
        {
            var movies = await _context.Movies
                .Select(m => new MovieDTO() 
                {
                    ID = m.ID,
                    Name = m.Name,
                    AgeRating = m.AgeRating,
                    Duration = m.Duration,
                    Trailer = m.Trailer,
                    Description = m.Description,
                    ReleaseDate = m.ReleaseDate,
                    Screenings = (_context.Screenings
                            .Where(s => s.MovieID == m.ID)
                            .Select(s => new ScreeningDTO()
                            {
                                ID = s.ID,
                                DateTime = s.DateTime,
                                MovieID = m.ID, 
                                RoomID = s.RoomID
                            })
                            .OrderBy(s => s.DateTime)
                            .ToList()
                    ),
				})
                .ToListAsync();

            return movies;
        }

        public async Task<int> AddAsync(MovieDTO movie)
        {
            var newMovie = new Movie()
            {
                Name = movie.Name,
                AgeRating = movie.AgeRating,
                Duration = movie.Duration,
                Trailer = movie.Trailer,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate
            };

            await _context.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            return newMovie.ID;
        }

        public async Task UpdateAsync(MovieDTO movie)
        {
            var oldMovie = await _context.Movies
                 .Where(m => m.ID == movie.ID)
                 .Select(m => m)
                 .FirstOrDefaultAsync();

            if (oldMovie == null) return;

            oldMovie.Name = movie.Name;
            oldMovie.AgeRating = movie.AgeRating;
            oldMovie.Duration = movie.Duration;
            oldMovie.Description = movie.Description;
            oldMovie.ReleaseDate = movie.ReleaseDate;
            oldMovie.Trailer = movie.Trailer;
        }

        public async Task<bool> DeleteAsync(MovieDTO movie)
        {
            var movieToDelete = await _context.Movies
               .FirstOrDefaultAsync(x => x.ID == movie.ID);

            if (movieToDelete == null) return false;

            var screenings = await _context.Screenings
                .Where(s => movieToDelete.ID == s.MovieID)
                .Select(s => s)
                .ToListAsync();

            var seatScreenings = new List<List<SeatScreening>>();

            bool bookings = false;

            foreach (var screening in screenings) 
            {
                var seats = await _context.SeatScreenings
                    .Where(ss => ss.ScreeningID == screening.ID)
                    .ToListAsync();

                foreach (var seat in seats) 
                {
                    if (seat.BookingID != null) 
                    {
                        bookings = true;
                        break;
                    }
                }

                seatScreenings.Add(seats);
            }

            if (!bookings)
            {
                foreach (var ss in seatScreenings) 
                { 
                    _context.RemoveRange(ss);
                }
                _context.RemoveRange(screenings);
                _context.Movies.Remove(movieToDelete);

                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
