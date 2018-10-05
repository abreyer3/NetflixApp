namespace NetflixApp
{
    partial class NetflixApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetflixApp));
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_movies = new System.Windows.Forms.Button();
            this.listBox_movies = new System.Windows.Forms.ListBox();
            this.textBox_filename = new System.Windows.Forms.TextBox();
            this.label_movieID = new System.Windows.Forms.Label();
            this.label_avgRating = new System.Windows.Forms.Label();
            this.textBox_movieID = new System.Windows.Forms.TextBox();
            this.textBox_avgRating = new System.Windows.Forms.TextBox();
            this.btn_users = new System.Windows.Forms.Button();
            this.listBox_users = new System.Windows.Forms.ListBox();
            this.label_userID = new System.Windows.Forms.Label();
            this.label_occupation = new System.Windows.Forms.Label();
            this.textBox_userID = new System.Windows.Forms.TextBox();
            this.textBox_occupation = new System.Windows.Forms.TextBox();
            this.btn_quit = new System.Windows.Forms.Button();
            this.btn_getMovReviews = new System.Windows.Forms.Button();
            this.listBox_reviews = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_getUserReviews = new System.Windows.Forms.Button();
            this.trackBar_rating = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_rating = new System.Windows.Forms.TextBox();
            this.btn_addReview = new System.Windows.Forms.Button();
            this.btn_eachRating = new System.Windows.Forms.Button();
            this.btn_topMovies = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rating)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(591, 10);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 0;
            this.btn_browse.Text = "Browse...";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_movies
            // 
            this.btn_movies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_movies.Location = new System.Drawing.Point(12, 62);
            this.btn_movies.Name = "btn_movies";
            this.btn_movies.Size = new System.Drawing.Size(100, 28);
            this.btn_movies.TabIndex = 2;
            this.btn_movies.Text = "List Movies";
            this.btn_movies.UseVisualStyleBackColor = true;
            this.btn_movies.Click += new System.EventHandler(this.btn_movies_Click);
            // 
            // listBox_movies
            // 
            this.listBox_movies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_movies.FormattingEnabled = true;
            this.listBox_movies.HorizontalScrollbar = true;
            this.listBox_movies.ItemHeight = 15;
            this.listBox_movies.Location = new System.Drawing.Point(119, 62);
            this.listBox_movies.Name = "listBox_movies";
            this.listBox_movies.Size = new System.Drawing.Size(256, 334);
            this.listBox_movies.TabIndex = 3;
            this.listBox_movies.SelectedIndexChanged += new System.EventHandler(this.listBox_movies_SelectedIndexChanged);
            // 
            // textBox_filename
            // 
            this.textBox_filename.AllowDrop = true;
            this.textBox_filename.Location = new System.Drawing.Point(119, 13);
            this.textBox_filename.Name = "textBox_filename";
            this.textBox_filename.Size = new System.Drawing.Size(466, 20);
            this.textBox_filename.TabIndex = 1;
            this.textBox_filename.Text = "netflix-200k.mdf";
            // 
            // label_movieID
            // 
            this.label_movieID.AutoSize = true;
            this.label_movieID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_movieID.Location = new System.Drawing.Point(12, 111);
            this.label_movieID.Name = "label_movieID";
            this.label_movieID.Size = new System.Drawing.Size(58, 15);
            this.label_movieID.TabIndex = 4;
            this.label_movieID.Text = "Movie ID:";
            // 
            // label_avgRating
            // 
            this.label_avgRating.AutoSize = true;
            this.label_avgRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_avgRating.Location = new System.Drawing.Point(12, 166);
            this.label_avgRating.Name = "label_avgRating";
            this.label_avgRating.Size = new System.Drawing.Size(68, 15);
            this.label_avgRating.TabIndex = 5;
            this.label_avgRating.Text = "Avg Rating:";
            // 
            // textBox_movieID
            // 
            this.textBox_movieID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_movieID.Location = new System.Drawing.Point(13, 129);
            this.textBox_movieID.Name = "textBox_movieID";
            this.textBox_movieID.ReadOnly = true;
            this.textBox_movieID.Size = new System.Drawing.Size(100, 21);
            this.textBox_movieID.TabIndex = 6;
            // 
            // textBox_avgRating
            // 
            this.textBox_avgRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_avgRating.Location = new System.Drawing.Point(12, 184);
            this.textBox_avgRating.Name = "textBox_avgRating";
            this.textBox_avgRating.ReadOnly = true;
            this.textBox_avgRating.Size = new System.Drawing.Size(100, 21);
            this.textBox_avgRating.TabIndex = 7;
            // 
            // btn_users
            // 
            this.btn_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_users.Location = new System.Drawing.Point(672, 62);
            this.btn_users.Name = "btn_users";
            this.btn_users.Size = new System.Drawing.Size(100, 28);
            this.btn_users.TabIndex = 8;
            this.btn_users.Text = "List Users";
            this.btn_users.UseVisualStyleBackColor = true;
            this.btn_users.Click += new System.EventHandler(this.btn_users_Click);
            // 
            // listBox_users
            // 
            this.listBox_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_users.FormattingEnabled = true;
            this.listBox_users.ItemHeight = 15;
            this.listBox_users.Location = new System.Drawing.Point(410, 62);
            this.listBox_users.Name = "listBox_users";
            this.listBox_users.Size = new System.Drawing.Size(256, 334);
            this.listBox_users.TabIndex = 9;
            this.listBox_users.SelectedIndexChanged += new System.EventHandler(this.listBox_users_SelectedIndexChanged);
            // 
            // label_userID
            // 
            this.label_userID.AutoSize = true;
            this.label_userID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_userID.Location = new System.Drawing.Point(672, 111);
            this.label_userID.Name = "label_userID";
            this.label_userID.Size = new System.Drawing.Size(51, 15);
            this.label_userID.TabIndex = 10;
            this.label_userID.Text = "User ID:";
            // 
            // label_occupation
            // 
            this.label_occupation.AutoSize = true;
            this.label_occupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_occupation.Location = new System.Drawing.Point(672, 166);
            this.label_occupation.Name = "label_occupation";
            this.label_occupation.Size = new System.Drawing.Size(72, 15);
            this.label_occupation.TabIndex = 11;
            this.label_occupation.Text = "Occupation:";
            // 
            // textBox_userID
            // 
            this.textBox_userID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_userID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_userID.Location = new System.Drawing.Point(675, 130);
            this.textBox_userID.Name = "textBox_userID";
            this.textBox_userID.ReadOnly = true;
            this.textBox_userID.Size = new System.Drawing.Size(100, 21);
            this.textBox_userID.TabIndex = 12;
            // 
            // textBox_occupation
            // 
            this.textBox_occupation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_occupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_occupation.Location = new System.Drawing.Point(675, 185);
            this.textBox_occupation.Name = "textBox_occupation";
            this.textBox_occupation.ReadOnly = true;
            this.textBox_occupation.Size = new System.Drawing.Size(100, 21);
            this.textBox_occupation.TabIndex = 13;
            // 
            // btn_quit
            // 
            this.btn_quit.Location = new System.Drawing.Point(697, 518);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(75, 23);
            this.btn_quit.TabIndex = 15;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // btn_getMovReviews
            // 
            this.btn_getMovReviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_getMovReviews.Location = new System.Drawing.Point(12, 229);
            this.btn_getMovReviews.Name = "btn_getMovReviews";
            this.btn_getMovReviews.Size = new System.Drawing.Size(100, 28);
            this.btn_getMovReviews.TabIndex = 15;
            this.btn_getMovReviews.Text = "Get Reviews";
            this.btn_getMovReviews.UseVisualStyleBackColor = true;
            this.btn_getMovReviews.Click += new System.EventHandler(this.btn_getMovReviews_Click);
            // 
            // listBox_reviews
            // 
            this.listBox_reviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_reviews.FormattingEnabled = true;
            this.listBox_reviews.ItemHeight = 15;
            this.listBox_reviews.Location = new System.Drawing.Point(119, 402);
            this.listBox_reviews.Name = "listBox_reviews";
            this.listBox_reviews.Size = new System.Drawing.Size(547, 139);
            this.listBox_reviews.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Movies:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Users:";
            // 
            // btn_getUserReviews
            // 
            this.btn_getUserReviews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_getUserReviews.Location = new System.Drawing.Point(675, 229);
            this.btn_getUserReviews.Name = "btn_getUserReviews";
            this.btn_getUserReviews.Size = new System.Drawing.Size(100, 28);
            this.btn_getUserReviews.TabIndex = 18;
            this.btn_getUserReviews.Text = "Get Reviews";
            this.btn_getUserReviews.UseVisualStyleBackColor = true;
            this.btn_getUserReviews.Click += new System.EventHandler(this.btn_getUserReviews_Click);
            // 
            // trackBar_rating
            // 
            this.trackBar_rating.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar_rating.LargeChange = 4;
            this.trackBar_rating.Location = new System.Drawing.Point(672, 299);
            this.trackBar_rating.Maximum = 5;
            this.trackBar_rating.Minimum = 1;
            this.trackBar_rating.Name = "trackBar_rating";
            this.trackBar_rating.Size = new System.Drawing.Size(104, 45);
            this.trackBar_rating.TabIndex = 19;
            this.trackBar_rating.Value = 3;
            this.trackBar_rating.Scroll += new System.EventHandler(this.trackBar_rating_Scroll);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(672, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Rating:";
            // 
            // textBox_rating
            // 
            this.textBox_rating.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_rating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rating.Location = new System.Drawing.Point(724, 276);
            this.textBox_rating.Name = "textBox_rating";
            this.textBox_rating.ReadOnly = true;
            this.textBox_rating.Size = new System.Drawing.Size(48, 21);
            this.textBox_rating.TabIndex = 21;
            this.textBox_rating.Text = "3";
            // 
            // btn_addReview
            // 
            this.btn_addReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addReview.Location = new System.Drawing.Point(675, 350);
            this.btn_addReview.Name = "btn_addReview";
            this.btn_addReview.Size = new System.Drawing.Size(100, 28);
            this.btn_addReview.TabIndex = 22;
            this.btn_addReview.Text = "Add Review";
            this.btn_addReview.UseVisualStyleBackColor = true;
            this.btn_addReview.Click += new System.EventHandler(this.btn_addReview_Click);
            // 
            // btn_eachRating
            // 
            this.btn_eachRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eachRating.Location = new System.Drawing.Point(12, 288);
            this.btn_eachRating.Name = "btn_eachRating";
            this.btn_eachRating.Size = new System.Drawing.Size(100, 28);
            this.btn_eachRating.TabIndex = 23;
            this.btn_eachRating.Text = "Each Rating";
            this.btn_eachRating.UseVisualStyleBackColor = true;
            this.btn_eachRating.Click += new System.EventHandler(this.btn_eachRating_Click);
            // 
            // btn_topMovies
            // 
            this.btn_topMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_topMovies.Location = new System.Drawing.Point(12, 350);
            this.btn_topMovies.Name = "btn_topMovies";
            this.btn_topMovies.Size = new System.Drawing.Size(100, 28);
            this.btn_topMovies.TabIndex = 24;
            this.btn_topMovies.Text = "Top-N Movies";
            this.btn_topMovies.UseVisualStyleBackColor = true;
            this.btn_topMovies.Click += new System.EventHandler(this.btn_topMovies_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "About...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NetflixApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_topMovies);
            this.Controls.Add(this.btn_eachRating);
            this.Controls.Add(this.btn_addReview);
            this.Controls.Add(this.textBox_rating);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar_rating);
            this.Controls.Add(this.btn_getUserReviews);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_reviews);
            this.Controls.Add(this.btn_getMovReviews);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.textBox_occupation);
            this.Controls.Add(this.textBox_userID);
            this.Controls.Add(this.label_occupation);
            this.Controls.Add(this.label_userID);
            this.Controls.Add(this.listBox_users);
            this.Controls.Add(this.btn_users);
            this.Controls.Add(this.textBox_avgRating);
            this.Controls.Add(this.textBox_movieID);
            this.Controls.Add(this.label_avgRating);
            this.Controls.Add(this.label_movieID);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.textBox_filename);
            this.Controls.Add(this.listBox_movies);
            this.Controls.Add(this.btn_movies);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetflixApp";
            this.Text = "Netflix Database App";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_movies;
        private System.Windows.Forms.ListBox listBox_movies;
        private System.Windows.Forms.TextBox textBox_filename;
        private System.Windows.Forms.Label label_movieID;
        private System.Windows.Forms.Label label_avgRating;
        private System.Windows.Forms.TextBox textBox_movieID;
        private System.Windows.Forms.TextBox textBox_avgRating;
        private System.Windows.Forms.Button btn_users;
        private System.Windows.Forms.ListBox listBox_users;
        private System.Windows.Forms.Label label_userID;
        private System.Windows.Forms.Label label_occupation;
        private System.Windows.Forms.TextBox textBox_userID;
        private System.Windows.Forms.TextBox textBox_occupation;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_getMovReviews;
        private System.Windows.Forms.ListBox listBox_reviews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_getUserReviews;
        private System.Windows.Forms.TrackBar trackBar_rating;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_rating;
        private System.Windows.Forms.Button btn_addReview;
        private System.Windows.Forms.Button btn_eachRating;
        private System.Windows.Forms.Button btn_topMovies;
        private System.Windows.Forms.Button button1;
    }
}

