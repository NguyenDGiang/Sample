using Sample.Core.Entities;
using Sample.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.UploadFiles
{
    public class UploadFileRepository : Repository<UploadFile, Guid>, IUploadFileRepository
    {
        public UploadFileRepository(DatabaseContext appContext) : base(appContext)
        {
        }
    }
}
