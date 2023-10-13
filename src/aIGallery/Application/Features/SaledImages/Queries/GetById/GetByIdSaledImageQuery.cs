using Application.Features.SaledImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SaledImages.Queries.GetById;

public class GetByIdSaledImageQuery : IRequest<GetByIdSaledImageResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSaledImageQueryHandler : IRequestHandler<GetByIdSaledImageQuery, GetByIdSaledImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISaledImageRepository _saledImageRepository;
        private readonly SaledImageBusinessRules _saledImageBusinessRules;

        public GetByIdSaledImageQueryHandler(IMapper mapper, ISaledImageRepository saledImageRepository, SaledImageBusinessRules saledImageBusinessRules)
        {
            _mapper = mapper;
            _saledImageRepository = saledImageRepository;
            _saledImageBusinessRules = saledImageBusinessRules;
        }

        public async Task<GetByIdSaledImageResponse> Handle(GetByIdSaledImageQuery request, CancellationToken cancellationToken)
        {
            SaledImage? saledImage = await _saledImageRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _saledImageBusinessRules.SaledImageShouldExistWhenSelected(saledImage);

            GetByIdSaledImageResponse response = _mapper.Map<GetByIdSaledImageResponse>(saledImage);
            return response;
        }
    }
}