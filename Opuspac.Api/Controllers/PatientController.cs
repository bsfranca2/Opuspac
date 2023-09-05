﻿using Microsoft.AspNetCore.Mvc;
using Opuspac.Api.Models.Request;
using Opuspac.Core.Repositories;

namespace Opuspac.Api.Controllers;

[ApiController]
[Route("/patients")]
public class PatientController
{
    private readonly IPatientRepository _patientRepository;

    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    [HttpGet(Name = "GetPatient")]
    public async Task<IResult> Get()
    {
        var patients = await _patientRepository.SearchAsync();
        return Results.Ok(patients);
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] PatientRequestModel model)
    {
        var patient = model.ToPatient();
        await _patientRepository.CreateAsync(patient);

        return Results.Created("GetPatient", patient);
    }
}