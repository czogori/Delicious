using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Delicious.Models;

namespace Delicious
{
    public interface IBundleService
    {
        ReadOnlyCollection<Bundle> GetAll(string bundleName = "");
    }
}
