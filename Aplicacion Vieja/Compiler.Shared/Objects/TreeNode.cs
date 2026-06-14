using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Objects
{
    public class TreeNode
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
        public object value { get; set; }
        public List<TreeNode> Children { get; set; }
    }
}
