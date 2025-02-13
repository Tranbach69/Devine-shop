﻿using DevineShop.Application.Common;
using DevineShop.Application.Enum;
using DevineShop.Application.Mapper;
using DevineShop.Infastructure.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevineShop.Application.Handlers.TagHandler.Queries.All
{
    public class GetAllTagQuery : IRequest<Respond<IList<TagRespond>>>
    {
    }
    public class TagRespond
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, Respond<IList<TagRespond>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllTagQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Respond<IList<TagRespond>>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
        {
            var tagEntities = _unitOfWork.Tags.DGetAll();
            var tagsRespond = TagMapper.Mapper.Map<IList<TagRespond>>(tagEntities);
            return Respond<IList<TagRespond>>.Success(tagsRespond);
        }
    }
}
