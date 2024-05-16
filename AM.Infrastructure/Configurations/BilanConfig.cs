using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class BilanConfig : IEntityTypeConfiguration<Bilan>
    {
        public void Configure(EntityTypeBuilder<Bilan> builder)
        {
            builder
              .HasOne(r => r.MyPatient)
              .WithMany(p => p.Bilans)
              .HasForeignKey(r => r.CodePatient);


            builder
                .HasOne(r => r.MyInfirmier)
                .WithMany(f => f.Bilans)
                .HasForeignKey(r => r.CodeInfirmier);
            builder.HasKey(r => new
            {
                r.CodeInfirmier,
                r.CodePatient,
                r.DatePrelevement
            });



        }
    }
}
