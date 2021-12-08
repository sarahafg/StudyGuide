using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterface
{
    public interface IDataService 
    {
        Task<List<QuestionResponseModel>> GetAllQuestions();
        Task<QuestionResponseModel> GetQuestionByName(string name);
        Task<QuestionResponseModel> GetQuestionById(int id);
        Task<List<AnswerResponseModel>> GetAllAnswers();
        Task<AnswerResponseModel> GetAnswerByName(string name);
        Task<AnswerResponseModel> GetAnswerById(int id);
        Task<List<InteractionResponseModel>> GetAllInteractions();
        Task<InteractionResponseModel> GetInteractionById(int id);
        Task<List<InteractionResponseModel>> GetInteractionByQuestionId(int QuestionId);
        Task<List<InteractionResponseModel>> GetInteractionByAnswerId(int AnswerId);
        Task<InteractionResponseModel> GetCommentsByQuestionId(int QuestionId);
        Task<InteractionResponseModel> GetCommentsByAnswerId(int AnswerId);
    }
}
