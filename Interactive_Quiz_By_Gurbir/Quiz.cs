using System;
namespace Interactive_Quiz_By_Gurbir
{
	public class Quiz
	{
		private List<Question> _questionList = new List<Question>();
		private int _currentQuestionIndex = -1;
		private int _score = 0;

		public string Title { get; set; }

        public int Score
        {
            get { return _score; }
			private set { _score = value; }
        }

		public Quiz(string title)
		{
			Title = title;
			LoadQuestions();
		}

		private void LoadQuestions()
		{
            _questionList.Add(new MultipleChoiceQuestion
            {
                QuestionText = "What is the capital of France?",
                Points = 1,
                CorrectAnswer = "Paris",
                Choices = new string[] { "Berlin", "Madrid", "Paris", "London" }
            });

            _questionList.Add(new TrueFalseQuestion
            {
                QuestionText = "Australia is a continent",
                Points = 1,
                CorrectAnswer = "True"
            });


        }

        private Question GetQuestionWithoutAnswer()
        {
            if (_currentQuestionIndex < 0 || _currentQuestionIndex >= _questionList.Count)
            {
                throw new InvalidOperationException("No more questions available");
            }

            Question question = _questionList[_currentQuestionIndex];
            if (question is MultipleChoiceQuestion)
            {
                MultipleChoiceQuestion mcQuestion = (MultipleChoiceQuestion)question;
                MultipleChoiceQuestion newQuestion = new MultipleChoiceQuestion();
                newQuestion.QuestionText = mcQuestion.QuestionText;
                newQuestion.Points = mcQuestion.Points;
                newQuestion.Choices = mcQuestion.Choices;
                return newQuestion;
            }
            else if (question is TrueFalseQuestion)
            {
                TrueFalseQuestion tfQuestion = (TrueFalseQuestion)question;
                TrueFalseQuestion newQuestion = new TrueFalseQuestion
                {
                    QuestionText = tfQuestion.QuestionText,
                    Points = tfQuestion.Points,
                    CorrectAnswer = tfQuestion.CorrectAnswer
                };
                newQuestion.Points = tfQuestion.Points;
                return newQuestion;
            }
            else
            {
                return null;
            }
            
        }

        public Question GetNextQuestion()
        {
            _currentQuestionIndex++;
            return GetQuestionWithoutAnswer();
        }

        public void CheckUserAnswer(Question question, string userAnswer)
        {
            if(question.CorrectAnswer.Equals(userAnswer, StringComparison.OrdinalIgnoreCase))
            {
                Score++;
            }
        }


    }

	
}

