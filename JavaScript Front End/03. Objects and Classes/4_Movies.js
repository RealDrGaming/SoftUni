function movies(arr)
{
    let listOfMovies = [];

    for (let line of arr)
    {
        if (line.includes('addMovie'))
        {
            let name = line.split('addMovie ')[1];
            listOfMovies.push({name});
        }
        else if (line.includes('directedBy'))
        {
            let info = line.split('directedBy ')
            let name = info[0].trim();
            let director = info[1];
            let movie = listOfMovies.find((movieObj) => movieObj.name === name);

            if (movie)
            {
                movie.director = director;
            }
        }
        else if (line.includes('onDate'))
        {
            let info = line.split('onDate ');
            let name = info[0].trim();
            let date = info[1];
            let movie = listOfMovies.find((movieObj) => movieObj.name === name);

            if (movie) {
                movie.date = date;
            }
        }
    }
    for (let movies of listOfMovies)
    {
        if (movies.name && movies.director && movies.date)
        {
            console.log(JSON.stringify(movies))
        }
    }
}