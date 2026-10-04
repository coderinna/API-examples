const db = require('./dbconfig');

// Hae kaikki elokuvat
const getAllMovies = (req, res) => {
  db.query('SELECT * FROM movies', (err, result) => {
    if (err)
      console.error(err);
    else
      res.json(result.rows)
  })
}

// Hae elokuva tunnisteen mukaan
const getMovieById = (req, res) => {
  const query = {
    text: 'SELECT * FROM movies WHERE id = $1',
    values: [req.params.id],
  }

  db.query(query, (err, result) => {
    if (err) {
      return console.error('Error executing query', err.stack)
    }
    else {
      if (result.rows.length > 0)
        res.json(result.rows);
      else
        res.status(404).end();
    }
  })
}

// Lisää uusi elokuva
const addMovie = (req, res) => {
  const newMovie = req.body;

  const query = {
    text: 'INSERT INTO movies (title, director, year) VALUES ($1, $2, $3)',
    values: [newMovie.title, newMovie.director, newMovie.year],
  }
  
  db.query(query, (err, res) => {
    if (err) {
      return console.error('Error executing query', err.stack)
    }
  })
  
  res.json(newMovie);
}

// Poista elokuva
const deleteMovie = (req, res) => {
  const query = {
    text: 'DELETE FROM movies WHERE id = $1',
    values: [req.params.id],
  }

  db.query(query, (err, res) => {
    if (err) {
      return console.error('Error executing query', err.stack)
    }
  })

  res.status(204).end();
}

// Update movie
const updateMovie = (req, res) => {
  const editedMovie = req.body;

  const query = {
    text: 'UPDATE movies SET title=$1, director=$2, year=$3 WHERE id = $4',
    values: [editedMovie.title, editedMovie.director, editedMovie.year, req.params.id],
  }

  db.query(query, (err, res) => {
    if (err) {
      return console.error('Error executing query', err.stack)
    }
  })

  res.json(editedMovie);
}


  // Poista kaikki elokuvat
  const deleteAllMovies = () => {
    db.query('DELETE FROM movies', (err, res) => {
      if (err) {
        return console.error('Error executing query', err.stack)
      }
    })
  }

module.exports = {
  getAllMovies: getAllMovies,
  getMovieById: getMovieById,
  addMovie: addMovie,
  deleteMovie: deleteMovie,
  updateMovie: updateMovie,
  deleteAllMovies: deleteAllMovies
}

