using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Entities
{
    public class AppUser:IdentityUser
    {
        
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}
