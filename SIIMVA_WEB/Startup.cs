using MOTOR_WORKFLOW.Controllers;
using MOTOR_WORKFLOW.Services;
namespace MOTOR_WORKFLOW
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
            services.AddControllers();
            services.AddSwaggerGen();

            // configure DI for application services
            services.AddScoped<IAdjuntoService, AdjuntoService>();
            services.AddScoped<ICampos_x_formularioService, Campos_x_formularioService>();
            services.AddScoped<IFormularioService, FormularioService>();
            services.AddScoped<IIngresos_x_pasoService, Ingresos_x_pasoService>();
            services.AddScoped<IPasoService, PasoService>();
            services.AddScoped<ITipo_campoService, Tipo_campoService>();
            services.AddScoped<IValidacion_campoService, Validacion_campoService>();
            services.AddScoped<IValidacion_x_campo_formularioService, Validacion_x_campo_formularioService>();
            services.AddScoped<IWs_configura_campo_formularioService, Ws_configura_campo_formularioService>();
            services.AddScoped<IWs_contenido_campo_formularioService, Ws_contenido_campo_formularioService>();
            services.AddScoped<IWs_headers_parametersService, Ws_headers_parametersService>();
            services.AddScoped<IWs_url_parametersService, Ws_url_parametersService>();
            services.AddScoped<IWs_web_serviceService, Ws_web_serviceService>();
            services.AddScoped<Irest, rest>();

            services.AddScoped<IFormularioService, FormularioService>();
            services.AddScoped<IPasosService, PasosService>();
            services.AddScoped<ITramitesService, TramitesService>();
            services.AddScoped<ITramiteService, TramiteService>();
            services.AddScoped<Services.CIDI.IUsuariosServices, Services.CIDI.UsuariosService>();
            services.AddScoped<Services.LOGIN.IUsuarioConOficina, Services.LOGIN.UsuarioConOficina>();
            services.AddScoped<Services.IOficinasService, Services.OficinasService>();
            services.AddScoped<Services.IIngresos_x_pasoService, Services.Ingresos_x_pasoService>();
            services.AddScoped<Services.IContenido_ingreso_pasoService, Services.Contenido_ingreso_pasoService>();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            //}

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}