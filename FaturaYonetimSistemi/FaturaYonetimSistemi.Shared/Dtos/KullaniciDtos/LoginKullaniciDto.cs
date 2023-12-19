using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaturaYonetimSistemi.Shared.Dtos.KullaniciDtos
{
    public class LoginKullaniciDto
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
