using Application.UseCases.Travails.Dtos;
using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Prestations.Dtos;
using AutoMapper;
using Domain;

namespace Application;

public static class Mapper
{
    private static AutoMapper.Mapper _instance;
    
    public static AutoMapper.Mapper GetInstance()
    {
        return _instance ??= CreateMapper();
    }
    
    private static AutoMapper.Mapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            // Travails
            cfg.CreateMap<Travails, DtoInputCreateTravails>();
            cfg.CreateMap<Travails, DtoInputUpdateTravails>();
            cfg.CreateMap<Travails, DtoOutputTravails>();
            cfg.CreateMap<Travails, DbTravails>();
            cfg.CreateMap<DbTravails, Travails>();
            cfg.CreateMap<DbTravails, DtoOutputTravails>();
            cfg.CreateMap<DtoInputCreateTravails, Travails>();
            cfg.CreateMap<DtoInputUpdateTravails, Travails>();
            cfg.CreateMap<DtoInputCreateTravails, DbTravails>();
            cfg.CreateMap<DtoInputUpdateTravails, DbTravails>();
            
            // Horaires
            cfg.CreateMap<Horaires, DtoInputCreateHoraires>();
            cfg.CreateMap<Horaires, DtoInputUpdateHoraires>();
            cfg.CreateMap<Horaires, DtoOutputHoraires>();
            cfg.CreateMap<Horaires, DbHoraires>();
            cfg.CreateMap<DbHoraires, Horaires>();
            cfg.CreateMap<DbHoraires, DtoOutputHoraires>();
            cfg.CreateMap<DtoInputCreateHoraires, Horaires>();
            cfg.CreateMap<DtoInputUpdateHoraires, Horaires>();
            cfg.CreateMap<DtoInputCreateHoraires, DbHoraires>();
            cfg.CreateMap<DtoInputUpdateHoraires, DbHoraires>();
            
            // Prestations
            cfg.CreateMap<Prestations, DtoInputCreatePrestations>();
            cfg.CreateMap<Prestations, DtoInputUpdatePrestations>();
            cfg.CreateMap<Prestations, DtoOutputPrestations>();
            cfg.CreateMap<Prestations, DbPrestations>();
            cfg.CreateMap<DbPrestations, Prestations>();
            cfg.CreateMap<DbPrestations, DtoOutputPrestations>();
            cfg.CreateMap<DtoInputCreatePrestations, Prestations>();
            cfg.CreateMap<DtoInputUpdatePrestations, Prestations>();
            cfg.CreateMap<DtoInputCreatePrestations, DbPrestations>();
            cfg.CreateMap<DtoInputUpdatePrestations, DbPrestations>();
        });
        return new AutoMapper.Mapper(config);
    }
}
