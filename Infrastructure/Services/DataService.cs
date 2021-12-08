using ApplicationCore.Models;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DataService : IDataService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IInteractionRepository _interactionRepository;
        private readonly IAnswerRepository _answerRepository;

        public DataService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IInteractionRepository interactionRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _interactionRepository = interactionRepository;

        }

        public async Task<List<QuestionResponseModel>> GetAllQuestions()
        {
            //return (QuestionResponseModel)await _questionRepository.GetQuestions();

            var questions = await _questionRepository.GetAll();
            if (questions == null)
            {
                return null;
            }
            return (from questionDetails in questions
                    select new QuestionResponseModel
                    {
                        Id = questionDetails.Id,
                        Name = questionDetails.Name,
                        Questions = questionDetails.Questions,
                        AddedOn = questionDetails.AddedOn
                    }).ToList();
        }

        public async Task<List<InteractionResponseModel>> GetAllInteractions()
        {
            var inter = await _interactionRepository.GetInteractions();
            if (inter == null)
            {
                return null;
            }

            return (from interDetails in inter
                    select new InteractionResponseModel
                    {
                        Id = interDetails.Id,
                        QuestionName = interDetails.Question.Name,
                        AnswerName = interDetails.Answer.Name,
                        IntDate = interDetails.IntDate,
                        IntType = interDetails.IntType,
                        Comments = interDetails.Comments
                    }).ToList();
        }

        public async Task<List<AnswerResponseModel>> GetAllAnswers()
        {
            var answer = await _answerRepository.GetAll();
            if (answer == null)
            {
                return null;
            }
            return (from answerDetails in answer
                    select new AnswerResponseModel
                    {
                        Id = answerDetails.Id,
                        Name = answerDetails.Name,
                        Answers = answerDetails.Answers,
                        Comments = answerDetails.Comments
                    }).ToList();
        }

        public async Task<AnswerResponseModel> GetAnswerByName(string name)
        {
            var answer = await _answerRepository.GetAnswerByName(name);
            if (answer == null)
            {
                return null;
            }
            var answerDetails = new AnswerResponseModel
            {
                Id = answer.Id,
                Name = answer.Name,
                Comments = answer.Comments,
                Answers = answer.Answers
            };
            return answerDetails;
        }

        public async Task<AnswerResponseModel> GetAnswerById(int id)
        {
            var answer = await _answerRepository.GetAnswerById(id);
            if (answer == null)
            {
                return null;
            }
            var answerDetails = new AnswerResponseModel
            {
                Id = answer.Id,
                Name = answer.Name,
                Answers = answer.Answers,
                Comments = answer.Comments,
            };
            return answerDetails;
        }

        public async Task<QuestionResponseModel> GetQuestionByName(string name)
        {
            var question = await _questionRepository.GetQuestionByName(name);
            if (question == null)
            {
                return null;
            }
            var questionDetails = new QuestionResponseModel
            {
                Id = question.Id,
                Name = question.Name,
                Questions = question.Questions,
                AddedOn = question.AddedOn
            };
            return questionDetails;
        }

        public async Task<QuestionResponseModel> GetQuestionById(int id)
        {
            var question = await _questionRepository.GetQuestionById(id);
            if (question == null)
            {
                return null;
            }
            var questionDetails = new QuestionResponseModel
            {
                Id = question.Id,
                Name = question.Name,
                Questions = question.Questions,
                AddedOn = question.AddedOn
            };
            return questionDetails;
        }

        public async Task<InteractionResponseModel> GetInteractionById(int id)
        {
            var inter = await _interactionRepository.GetInteractionById(id);
            if (inter == null)
            {
                return null;
            }
            var interDetails = new InteractionResponseModel
            {
                Id = inter.Id,
                QuestionName = inter.Question.Name,
                AnswerName = inter.Answer.Name,
                IntDate = inter.IntDate,
                IntType = inter.IntType,
                Comments = inter.Comments,

            };
            return interDetails;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionByQuestionId(int QuestionId)
        {
            var inter = await _interactionRepository.GetInteractionByQuestionId(QuestionId);
            if (inter == null)
            {
                return null;
            }
            return (from interDetails in inter
                    select new InteractionResponseModel
                    {
                        Id = interDetails.Id,
                        QuestionName = interDetails.Question.Name,
                        AnswerName = interDetails.Answer.Name,
                        IntDate = interDetails.IntDate,
                        IntType = interDetails.IntType,
                        Comments = interDetails.Comments

                    }).ToList();
        }

        public async Task<List<InteractionResponseModel>> GetInteractionByAnswerId(int AnswerId)
        {
            var inter = await _interactionRepository.GetInteractionByAnswerId(AnswerId);
            if (inter == null)
            {
                return null;
            }
            return (from interDetails in inter
                    select new InteractionResponseModel
                    {
                        Id = interDetails.Id,
                        QuestionName = interDetails.Question.Name,
                        AnswerName = interDetails.Answer.Name,
                        IntDate = interDetails.IntDate,
                        IntType = interDetails.IntType,
                        Comments = interDetails.Comments

                    }).ToList();
        }

        public async Task<InteractionResponseModel> GetCommentsByQuestionId(int QuestionId)
        {
            var inter = await _interactionRepository.GetCommentsByQuestionId(QuestionId);
            if (inter == null)
            {
                return null;
            }
            var interDetails = new InteractionResponseModel
            {
                Id = inter.Id,
                QuestionName = inter.Question.Name,
                AnswerName = inter.Answer.Name,
                IntDate = inter.IntDate,
                IntType = inter.IntType,
                Comments = inter.Comments,

            };
            return interDetails;
        }

        public async Task<InteractionResponseModel> GetCommentsByAnswerId(int AnswerId)
        {
            var inter = await _interactionRepository.GetCommentsByAnswerId(AnswerId);
            if (inter == null)
            {
                return null;
            }
            var interDetails = new InteractionResponseModel
            {
                Id = inter.Id,
                QuestionName = inter.Question.Name,
                AnswerName = inter.Answer.Name,
                IntDate = inter.IntDate,
                IntType = inter.IntType,
                Comments = inter.Comments,

            };
            return interDetails;
        }
    }
}
