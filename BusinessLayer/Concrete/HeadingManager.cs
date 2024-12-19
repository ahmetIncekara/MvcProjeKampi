using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using EntityLayer.Concretes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        private HeadingValidator _validator = new HeadingValidator();

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public ValidationResult ValidateHeading(Heading heading)
        {
            return _validator.Validate(heading);
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List(x => x.HeadingStatus == true);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id && x.HeadingStatus == true);
        }

        public HeadingResult HeadingAdd(Heading heading)
        {
            ValidationResult validationResult = ValidateHeading(heading);
            if (!validationResult.IsValid)
            {
                return new HeadingResult(false, validationResult.Errors.Select(e => new ValidationError
                {
                    PropertyName = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList());
            }

            _headingDal.Insert(heading);
            return new HeadingResult(true, null, heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
