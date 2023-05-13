using Microsoft.EntityFrameworkCore;

namespace WebApp_Noite
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions<Contexto> opt)
            :base(opt){ }
    }
}
