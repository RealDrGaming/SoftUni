Dictionary<string, int> dic = new Dictionary<string, int>();

/*
 * 
 * NA IZPITA SHTE GO IMA SMESHKO
 * 
 */

//Sorts by key ascending
dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);

//Sorts by value ascending
dic = dic.OrderBy(d => d.Value).ToDictionary(d => d.Key, d => d.Value);

//Sorts by key, then by value ascending
dic = dic.OrderBy(d => d.Key).ThenBy(d => d.Value).ToDictionary(d => d.Key, d => d.Value);

//Sorts by key descending
dic = dic.OrderByDescending(d => d.Key).ToDictionary(d => d.Key, d => d.Value);

//Sorts by value descending
dic = dic.OrderByDescending(d => d.Value).ToDictionary(d => d.Key, d => d.Value);