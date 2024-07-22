public class Solution {
    public string[] SortPeople(string[] names, int[] heights) {
          
        var people = names.Zip(heights, (name, height) =>
         new { Name = name, Height = height }).ToList();

        var sortedPeople = people.OrderByDescending(p => p.Height).ToList();

        var sortedNames = sortedPeople.Select(p => p.Name).ToArray();

        return sortedNames;
    }
}