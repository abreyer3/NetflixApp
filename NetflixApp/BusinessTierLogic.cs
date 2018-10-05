//
// BusinessTier:  business logic, acting as interface between UI and data store.
//
/*
 * Allen Breyer III
 * U. of Illinois, Chicago
 * CS341, Spring 2018
 * Final Project
 */

using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessTier
{

    //
    // Business:
    //
    public class Business
    {
        //
        // Fields:
        //
        private string _DBFile;
        private DataAccessTier.Data dataTier;


        //
        // Constructor:
        //
        public Business(string DatabaseFilename)
        {
            _DBFile = DatabaseFilename;

            dataTier = new DataAccessTier.Data(DatabaseFilename);
        }


        //
        // TestConnection:
        //
        // Returns true if we can establish a connection to the database, false if not.
        //
        public bool TestConnection()
        {
            return dataTier.TestConnection();
        }


        //
        // GetNamedUser:
        //
        // Retrieves User object based on USER NAME; returns null if user is not
        // found.
        //
        // NOTE: there are "named" users from the Users table, and anonymous users
        // that only exist in the Reviews table.  This function only looks up "named"
        // users from the Users table.
        //
        public User GetNamedUser(string UserName)
        {
            //
            // DONE!
            //

            string value = UserName.Replace("'", "''");

            string sql = string.Format(@"
                SELECT UserName, UserID, Occupation 
                FROM Users 
                WHERE UserName = '{0}'", value);

            object result = dataTier.ExecuteScalarQuery(sql);

            if (result != null)
            {
                DataSet ds = dataTier.ExecuteNonScalarQuery(sql);
                DataTable dt = ds.Tables["TABLE"];
                DataRow row = dt.Rows[0];

                User user = new User(Convert.ToInt32(row["UserID"]), UserName, row["Occupation"].ToString());
                return user;
            }

            return null;
        }


        //
        // GetAllNamedUsers:
        //
        // Returns a list of all the users in the Users table ("named" users), sorted 
        // by user name.
        //
        // NOTE: the database also contains lots of "anonymous" users, which this 
        // function does not return.
        //
        public IReadOnlyList<User> GetAllNamedUsers()
        {
            List<User> users = new List<User>();

            //
            // DONE!
            //

            string sql = (@"
                SELECT * 
                FROM Users 
                ORDER BY UserName ASC");

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = ds.Tables["TABLE"];

            foreach (DataRow row in dt.Rows)
            {
                User user = new User(Convert.ToInt32(row["UserID"]), row["UserName"].ToString(), row["Occupation"].ToString());
                users.Add(user);
            }

            return users;
        }


        //
        // GetMovie:
        //
        // Retrieves Movie object based on MOVIE ID; returns null if movie is not
        // found.
        //
        public Movie GetMovie(int MovieID)
        {
            //
            // DONE!
            //

            string sql = string.Format(@"
                SELECT MovieName 
                FROM Movies 
                WHERE MovieID = {0}", MovieID.ToString());

            object movieName = dataTier.ExecuteScalarQuery(sql);

            if (movieName != null)
            {
                Movie movie = new Movie(MovieID, movieName.ToString());
                return movie;
            }

            return null;
        }


        //
        // GetMovie:
        //
        // Retrieves Movie object based on MOVIE NAME; returns null if movie is not
        // found.
        //
        public Movie GetMovie(string MovieName)
        {
            //
            // DONE!
            //

            string value = MovieName.Replace("'", "''");

            string sql = string.Format(@"
                SELECT MovieID 
                FROM Movies 
                WHERE MovieName = '{0}'", value);

            object result = dataTier.ExecuteScalarQuery(sql);

            if (result != null)
            {
                Movie movie = new Movie(Convert.ToInt32(result), value);
                return movie;
            }

            return null;
        }


        //
        // AddReview:
        //
        // Adds review based on MOVIE ID, returning a Review object containing
        // the review, review's id, etc.  If the add failed, null is returned.
        //
        public Review AddReview(int MovieID, int UserID, int Rating)
        {
            //
            // DONE!
            //

            string sql = string.Format(@"
                INSERT INTO Reviews(MovieID, UserID, Rating) VALUES ({0}, {1}, {2}); 
                SELECT ReviewID FROM Reviews WHERE ReviewID = SCOPE_IDENTITY();", MovieID, UserID, Rating);

            object result = dataTier.ExecuteScalarQuery(sql);

            if (result != DBNull.Value)
            {
                Review review = new Review(Convert.ToInt32(result), MovieID, UserID, Rating);
                return review;
            }

            return null;
        }


        //
        // GetMovieDetail:
        //
        // Given a MOVIE ID, returns detailed information about this movie --- all
        // the reviews, the total number of reviews, average rating, etc.  If the 
        // movie cannot be found, null is returned.
        //
        public MovieDetail GetMovieDetail(int MovieID)
        {
            //
            // DONE!
            //

            if (GetMovie(MovieID) == null)
            {
                return null;
            }

            string value = GetMovie(MovieID).MovieName.Replace("'", "''");

            string sql1 = string.Format(@"
                SELECT ROUND (AVG (CAST (Rating AS Float)), 4) AS AvgRating 
                FROM Reviews 
                INNER JOIN Movies ON Reviews.MovieID = Movies.MovieID 
                WHERE MovieName = '{0}';", value);

            object averageRating = dataTier.ExecuteScalarQuery(sql1);

            string sql2 = string.Format(@"
                SELECT COUNT (Rating) 
                FROM Reviews 
                WHERE MovieID = {0}", MovieID);

            object numberRatings = dataTier.ExecuteScalarQuery(sql2);

            string sql3 = string.Format(@"
                SELECT UserID, Rating, ReviewID 
                FROM Reviews 
                WHERE MovieID = {0} 
                ORDER BY Rating Desc, UserID ASC;", MovieID);

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql3);

            DataTable dt = ds.Tables["TABLE"];
            List<Review> reviews = new List<Review>();

            foreach (DataRow row in dt.Rows)
            {
                reviews.Add(new Review(Convert.ToInt32(row["ReviewID"]), MovieID, Convert.ToInt32(row["UserID"]), Convert.ToInt32(row["Rating"])));
            }

            if (reviews.Count <= 0)
            {
                numberRatings = 0;
                averageRating = 0;
            }

            MovieDetail movieDetail = new MovieDetail(GetMovie(MovieID), Convert.ToDouble(averageRating), Convert.ToInt32(numberRatings), reviews);
            return movieDetail;
        }


        //
        // GetUserDetail:
        //
        // Given a USER ID, returns detailed information about this user --- all
        // the reviews submitted by this user, the total number of reviews, average 
        // rating given, etc.  If the user cannot be found, null is returned.
        //
        public UserDetail GetUserDetail(int UserID)
        {
            //
            // DONE!
            //

            List<Review> reviews = new List<Review>();

            string sql = string.Format(@"
                SELECT UserID, UserName, Occupation 
                FROM Users 
                WHERE UserID = {0}", UserID);

            object result = dataTier.ExecuteScalarQuery(sql);

            if (result != null)
            {
                DataSet ds = dataTier.ExecuteNonScalarQuery(sql);
                DataTable dt = ds.Tables["TABLE"];
                DataRow row = dt.Rows[0];

                User user = new User(UserID, row["UserName"].ToString(), row["Occupation"].ToString());

                string sql1 = string.Format(@"
                    SELECT ROUND (AVG (CAST (Rating AS Float)), 4) 
                    FROM Reviews 
                    WHERE UserID = {0}", UserID);

                object averageRating = dataTier.ExecuteScalarQuery(sql1);

                string sql2 = string.Format(@"
                    SELECT COUNT(Rating) 
                    FROM Reviews 
                    WHERE UserID = {0}", UserID);

                object numberRatings = dataTier.ExecuteScalarQuery(sql2);

                string sql3 = string.Format(@"
                    SELECT MovieID, Rating, ReviewID
                    FROM Reviews 
                    WHERE UserID = {0}
                    ORDER BY Rating Desc, UserID ASC;", UserID);

                DataSet ds2 = dataTier.ExecuteNonScalarQuery(sql3);

                DataTable dt2 = ds2.Tables["TABLE"];

                foreach (DataRow row2 in dt2.Rows)
                {
                    reviews.Add(new Review(Convert.ToInt32(row2["ReviewID"]), Convert.ToInt32(row2["MovieID"]), UserID, Convert.ToInt32(row2["Rating"])));
                }

                if (reviews.Count <= 0)
                {
                    averageRating = 0;
                    numberRatings = 0;
                }

                UserDetail userDetail = new UserDetail(user, Convert.ToDouble(averageRating), Convert.ToInt32(numberRatings), reviews);

                return userDetail;
            }

            return null;
        }


        //
        // GetTopMoviesByAvgRating:
        //
        // Returns the top N movies in descending order by average rating.  If two
        // movies have the same rating, the movies are presented in ascending order
        // by name.  If N < 1, an EMPTY LIST is returned.
        //
        public IReadOnlyList<Movie> GetTopMoviesByAvgRating(int N)
        {
            List<Movie> movies = new List<Movie>();

            //
            // TODO!
            //

            string sql = string.Format(@"
                SELECT COUNT(*) 
                FROM Movies");

            var count = Convert.ToInt32(dataTier.ExecuteScalarQuery(sql));

            if ((N <= count) && (N > 0))
            {
                DataSet ds = dataTier.ExecuteNonScalarQuery(string.Format(@"
                    SELECT TOP {0} Movies.MovieName, Movies.MovieID, Result.AvgRating 
                    FROM Movies 
                    INNER JOIN (
                        SELECT MovieID, ROUND (AVG (CAST (Rating AS Float)), 4) as AvgRating 
                        FROM Reviews 
                        GROUP BY MovieID ) As Result
                    ON Result.MovieID = Movies.MovieID 
                    ORDER BY Result.AvgRating DESC, Movies.MovieName Asc;", N));

                DataTable dt = ds.Tables["TABLE"];

                foreach(DataRow row in dt.Rows)
                {
                    Movie movie = new Movie(Convert.ToInt32(row["MovieID"]), row["MovieName"].ToString());
                    movies.Add(movie);
                }

                return movies;
            }

            return null;
        }


        //
        // GetAllMovies
        //
        // Returns a read-only list of Movie objects.
        //
        public IReadOnlyList<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            string sql = string.Format(@"
                SELECT * 
                FROM Movies 
                ORDER BY MovieName ASC");

            DataSet ds = dataTier.ExecuteNonScalarQuery(sql);
            DataTable dt = ds.Tables["TABLE"];

            foreach(DataRow row in dt.Rows)
            {
                Movie movie = new Movie(Convert.ToInt32(row["MovieID"]), row["MovieName"].ToString());
                movies.Add(movie);
            }

            return movies;
        }


    }//class
}//namespace
