using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;



namespace SiCAEWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<SiCAEContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("SiCAEConnection")));
            // DiaHora
            services.AddTransient<IHorarioService, HorarioService>();
            // Aluno
            services.AddTransient<IAlunoService, AlunoService>();
            // Disciplina
            services.AddTransient<IDisciplinaService, DisciplinaService>();
            // Escola
            services.AddTransient<IEscolaService, EscolaService>();
            // Pessoa
            services.AddTransient<IPessoaService, PessoaService>();
            // Turma
            services.AddTransient<ITurmaService, TurmaService>();
            // Notificacao
            services.AddTransient<INotificacaoService, NotificacaoService>();
            // Cidade
            services.AddTransient<ICidadeService, CidadeService>();
            //Aula
            services.AddTransient<IAulaService, AulaService>();
            // Mapeando tudo
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
