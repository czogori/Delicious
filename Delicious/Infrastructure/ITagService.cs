using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Delicious
{
    public interface ITagService
    {
        ReadOnlyCollection<Tag> GetAll();
        bool Delete(string name);
        bool Rename(string oldName, string newName);
    }
}
