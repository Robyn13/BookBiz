using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._1_EntityFrameworkIntro.Entities;
using Highway.Data;
using Highway.Data.EventManagement.Interfaces;

namespace BookBiz._2_CQRSIntro
{
    public class BookBizDomain : IDomain
    {
        public BookBizDomain(string connectionString)
        {
            ConnectionString = connectionString;
            Mappings = new BookBizEntityMapping();
            Context = new DefaultContextConfiguration();
            Events = new List<IInterceptor>();
        }

        public string ConnectionString { get; }
        public IMappingConfiguration Mappings { get; }
        public IContextConfiguration Context { get; }
        public List<IInterceptor> Events { get; }
    }
}
