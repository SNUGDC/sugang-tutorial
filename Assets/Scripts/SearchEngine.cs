using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SearchEngine
{
    // TODO: database is not implemented yet.
    List<Subject> subjects;

    public List<Subject> Search(string subjectName)
    {
        return subjects
            .Where(subject => subject.name.Contains(subjectName))
            .ToList();
    }
}
