/*
 * Netflix Database Application using N-Tier Design.
 * 
 * Allen Breyer III
 * U. of Illinois, Chicago
 * CS341, Spring 2018
 * Project 08
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NetflixApp
{
    public partial class NetflixApp : Form
    {
        public NetflixApp()
        {
            InitializeComponent();
        }

        private void clearForm()
        {
            this.listBox_movies.Items.Clear();
            this.listBox_users.Items.Clear();
            this.textBox_movieID.Clear();
            this.textBox_avgRating.Clear();
            this.textBox_userID.Clear();
            this.textBox_occupation.Clear();
            this.listBox_reviews.Items.Clear();
        }

        // Checks to see if the file actually exists
        private bool fileExists(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                string msg = string.Format("ERROR: Input file not found: '{0}'", filename);
                MessageBox.Show(msg);
                return false;
            }
            return true;
        }



        // View all movies in a list in alphabetical order by movie name
        private void btn_movies_Click(object sender, EventArgs e)
        {
            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            this.listBox_movies.Items.Clear();
            this.textBox_movieID.Clear();
            this.textBox_avgRating.Clear();
            this.listBox_reviews.Items.Clear();

            /*string version, connectionInfo;
            SqlConnection db;

            version = "MSSQLLocalDB";
            connectionInfo = String.Format(@"
                Data Source=(LocalDB)\{0};AttachDbFilename=|DataDirectory|\{1};Integrated Security=True;
                ", version, filename);

            db = new SqlConnection(connectionInfo);
            db.Open();

            string sql = string.Format(@"
                SELECT MovieName
                FROM Movies
                ORDER BY MovieName ASC;");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandText = sql;
            adapter.Fill(ds);

            db.Close();

            foreach (DataRow row in ds.Tables["TABLE"].Rows)
            {
                string movieName = string.Format("{0}", Convert.ToString(row["MovieName"]));
                this.listBox_movies.Items.Add(movieName);
            }*/

            BusinessTier.Business biztier = new BusinessTier.Business(this.textBox_filename.Text);
            IReadOnlyList<BusinessTier.Movie> movies = biztier.GetAllMovies();

            foreach (BusinessTier.Movie movie in movies)
            {
                this.listBox_movies.Items.Add(movie.MovieName);
            }

            this.Cursor = Cursors.Default;
        }



        // Browse and choose an .mdf file in your directory
        private void btn_browse_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "SQL Server Database File (*.mdf)|*.mdf|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                clearForm();
                this.textBox_filename.Text = file.SafeFileName;
            }
        }



        // When selecting a movie in the list, retrieve its id and average rating
        private void listBox_movies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string movieName = this.listBox_movies.Text;

            this.textBox_movieID.Clear();
            this.textBox_avgRating.Clear();

            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            BusinessTier.Movie movie = biztier.GetMovie(movieName);

            if (movie == null)
            {
                MessageBox.Show("ERROR: Movie not found!");
                return;
            }

            this.textBox_movieID.Text = movie.MovieID.ToString();
            BusinessTier.MovieDetail movieDetails = biztier.GetMovieDetail(movie.MovieID);

            if (movieDetails == null)
            {
                MessageBox.Show("ERROR: MovieID possibly corrupted!");
                return;
            }

            this.textBox_avgRating.Text = movieDetails.AvgRating.ToString();
        }



        // View all users in a list in alphabetical order by username
        private void btn_users_Click(object sender, EventArgs e)
        {
            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            this.listBox_users.Items.Clear();
            this.textBox_userID.Clear();
            this.textBox_occupation.Clear();

            BusinessTier.Business biztier = new BusinessTier.Business(this.textBox_filename.Text);
            IReadOnlyList<BusinessTier.User> users = biztier.GetAllNamedUsers();

            foreach (BusinessTier.User user in users)
            {
                this.listBox_users.Items.Add(user.UserName.ToString());
            }

            this.Cursor = Cursors.Default;
        }



        // When selecting a user in the list, retrieve their id and occupation
        private void listBox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userName = this.listBox_users.Text;

            this.textBox_userID.Clear();
            this.textBox_occupation.Clear();

            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            BusinessTier.User user = biztier.GetNamedUser(userName);

            if (user == null)
            {
                MessageBox.Show("ERROR: User not found!");
                return;
            }

            this.textBox_userID.Text = user.UserID.ToString();
            this.textBox_occupation.Text = user.Occupation.ToString();
        }



        // Quit the program
        private void btn_quit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        // Get all reviews for a particular movie selected
        private void btn_getMovReviews_Click(object sender, EventArgs e)
        {
            this.listBox_reviews.Items.Clear();

            if(this.listBox_movies.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            string movieName = this.listBox_movies.Text;
            int movieID = System.Int32.Parse(this.textBox_movieID.Text);

            this.listBox_reviews.Items.Add(movieName);
            this.listBox_reviews.Items.Add("");

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            BusinessTier.MovieDetail details = biztier.GetMovieDetail(movieID);

            var reviews = details.Reviews;

            if (reviews.Count <= 0)
            {
                string line = "-No reviews-";
                this.listBox_reviews.Items.Add(line);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            foreach (var review in reviews)
            {
                string line = string.Format("{0}: {1}", review.UserID, review.Rating);

                this.listBox_reviews.Items.Add(line);
            }

            this.Cursor = Cursors.Default;
        }



        // Get all reviews entered by a particular Netflix user
        private void btn_getUserReviews_Click(object sender, EventArgs e)
        {
            this.listBox_reviews.Items.Clear();

            if (this.listBox_users.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }

            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            string userName = this.listBox_users.Text;
            int userID = System.Int32.Parse(this.textBox_userID.Text);

            this.listBox_reviews.Items.Add(userName);
            this.listBox_reviews.Items.Add("");

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            BusinessTier.UserDetail details2 = biztier.GetUserDetail(userID);

            var reviews2 = details2.Reviews;

            if (reviews2.Count <= 0)
            {
                string line = "-No reviews-";
                this.listBox_reviews.Items.Add(line);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            foreach (var review in reviews2)
            {
                BusinessTier.MovieDetail details = biztier.GetMovieDetail(review.MovieID);

                string line = string.Format("{0} -> {1}", details.movie.MovieName, review.Rating);

                this.listBox_reviews.Items.Add(line);
            }

            this.Cursor = Cursors.Default;
        }



        // Shows the rating value selected on the slider control
        private void trackBar_rating_Scroll(object sender, EventArgs e)
        {
            this.textBox_rating.Text = ("" + trackBar_rating.Value);
        }



        // Insert a new review for an existing movie and an existing Netflix user
        private void btn_addReview_Click(object sender, EventArgs e)
        {
            if (this.listBox_movies.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            if (this.listBox_users.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a user...");
                return;
            }

            if (this.trackBar_rating.Value < 1 || this.trackBar_rating.Value > 5)
            {
                MessageBox.Show("Please select a valid rating...");
                return;
            }

            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            int movieID = System.Int32.Parse(this.textBox_movieID.Text);
            int userID = System.Int32.Parse(this.textBox_userID.Text);
            int rating = this.trackBar_rating.Value;

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            biztier.AddReview(movieID, userID, rating);

            this.Cursor = Cursors.Default;
            MessageBox.Show("Review successfully added!");
        }



        // Summarize the ratings for a particular movie selected
        private void btn_eachRating_Click(object sender, EventArgs e)
        {
            this.listBox_reviews.Items.Clear();

            if (this.listBox_movies.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a movie...");
                return;
            }

            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }

            string movieName = this.listBox_movies.Text;
            int movieID = System.Int32.Parse(this.textBox_movieID.Text);

            this.listBox_reviews.Items.Add(movieName);
            this.listBox_reviews.Items.Add("");

            BusinessTier.Business biztier = new BusinessTier.Business(this.textBox_filename.Text);
            BusinessTier.MovieDetail details = biztier.GetMovieDetail(movieID);

            var reviews = details.Reviews;

            if (reviews.Count <= 0)
            {
                string line = "-No reviews-";
                this.listBox_reviews.Items.Add(line);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var query = from r in details.Reviews
                        group r by r.Rating into grp
                        orderby grp.Key descending
                        select new
                        {
                            Rating = grp.Key,
                            Count = grp.Count()
                        };

            foreach(var tuple in query)
            {
                string line = string.Format("{0}: {1}", tuple.Rating, tuple.Count);

                this.listBox_reviews.Items.Add(line);
            }

            this.Cursor = Cursors.Default;
        }



        // Display the top N movies by average rating using user input
        private void btn_topMovies_Click(object sender, EventArgs e)
        {
            string filename = this.textBox_filename.Text;

            if (!fileExists(filename))
            {
                return;
            }


            Form2 testDialog = new Form2();
            int value = 0;

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                value = testDialog.userInput;
            }
            else
            {
                return;
            }
            testDialog.Dispose();


            this.Cursor = Cursors.WaitCursor;

            this.listBox_reviews.Items.Clear();

            BusinessTier.Business biztier = new BusinessTier.Business(filename);
            var topMovies = biztier.GetTopMoviesByAvgRating(value);
            int i = 1;

            foreach (var list in topMovies)
            {
                BusinessTier.MovieDetail details = biztier.GetMovieDetail(list.MovieID);

                this.listBox_reviews.Items.Add(i + ") " + list.MovieName.ToString() + ": " + details.AvgRating);
                i++;
            }

            this.Cursor = Cursors.Default;
        }



        // About my program. Also wanted to make the program look more symmetrical :P
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Netflix Database Application using N-tier Design" +
                "\n" + "by Allen Breyer III");
        }
    }
}
