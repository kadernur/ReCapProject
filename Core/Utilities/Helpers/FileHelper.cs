using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
   public  class FileHelper
    {
       

        public static string AddAsync(IFormFile file)
        {
            var result = PathAndNameCreator(file);

            try
            {
                var sourcePath = Path.GetTempFileName();
                using (var stream =new FileStream(sourcePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                File.Move(sourcePath, result.path);


            }
            catch (Exception exception )
            {

                return exception.Message;
            }
            return result.pathAndName;
             
        
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = PathAndNameCreator(file);

            try
            {
                using (var fileStream = new FileStream(result.path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result.pathAndName;
        }


        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }


       


        private static (string path, string pathAndName) PathAndNameCreator(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

           



           var uniqueFileName = Guid.NewGuid().ToString("N") + fileExtension;

            string result = $@"{Environment.CurrentDirectory +
                @"\wwroot\Images"}\{uniqueFileName}";
            return (result, $@"\Images\{uniqueFileName}");


        }
    }
}
