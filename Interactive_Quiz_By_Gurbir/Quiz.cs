using System;
namespace Interactive_Quiz_By_Gurbir
{
	public class Quiz
	{
        private List<Question> _questionList; 
		private int _currentQuestionIndex = -1;
        private bool _isAnswered = false;
        private int _score;
      
       
		public int Score { get { return _score; } private set { _score = value; } }

		public string Title { get; set; }

       
		public Quiz(string title)
		{
            Title = title;
            _questionList = new List<Question>();
			LoadQuestions();
		}

		private void LoadQuestions()
		{
            _questionList.Add(new MultipleChoiceQuestion
            {
                QuestionText = "What is the capital of France?",
                Points = 1,
                Choices = new List<string> { "Berlin", "Madrid", "Paris", "London" },
                CorrectAnswer = "Paris"
            });

            _questionList.Add(new MultipleChoiceQuestion
            {
                QuestionText = "Which planet is closest to the sun?",
                Points = 1,
                Choices = new List<string> { "Mercury", "Venus", "Earth", "Mars" },
                CorrectAnswer = "Mercury"
            });

            _questionList.Add(new MultipleChoiceQuestion
            {
                QuestionText = "What is the largest organ in the human body?",
                Points = 1,
                Choices = new List<string> { "Brain", "Skin", "Heart", "Liver" },
                CorrectAnswer = "Skin"
            });

            _questionList.Add(new MultipleChoiceQuestion
            {
                QuestionText = "What is the tallest mammal?",
                Points = 1,
                Choices = new List<string> { "Hippopotamus", "Elephant", "Giraffe", "Rhino" },
                CorrectAnswer = "Giraffe"
            });

            _questionList.Add(new MultipleChoiceQuestion
            {
                QuestionText = "Which of these is not a type of triangle?",
                Points = 1,
                Choices = new List<string> { "Right", "Equilateral", "Isoceles", "Square" },
                CorrectAnswer = "Square"
            });
            

            _questionList.Add(new TrueFalseQuestion
            {
                QuestionText = "Australia is a continent",
                Points = 1,
                CorrectAnswer = "True"
            });

            _questionList.Add(new TrueFalseQuestion
            {
                QuestionText = "The Nile is the longest river in the world",
                Points = 1,
                CorrectAnswer = "True"
            });

            _questionList.Add(new TrueFalseQuestion
            {
                QuestionText = "The Great Wall of China can be seen from space",
                Points = 1,
                CorrectAnswer = "False"
            });

            _questionList.Add(new TrueFalseQuestion
            {
                QuestionText = "The human body has four lungs",
                Points = 1,
                CorrectAnswer = "False"
            });

            _questionList.Add(new TrueFalseQuestion
            {
                QuestionText = "Mount Kilimanjaro is the highest mountain in the world",
                Points = 1,
                CorrectAnswer = "False"
            });


        }

        private Question GetQuestionWithoutAnswer()
        {
            if (_currentQuestionIndex < 0 || _currentQuestionIndex >= _questionList.Count)
            {
                throw new InvalidOperationException("No more questions available");
            }

            Question question = _questionList[_currentQuestionIndex];
            if (question is MultipleChoiceQuestion mcq)
            {
                return new MultipleChoiceQuestion
                {
                    QuestionText = mcq.QuestionText,
                    Choices = mcq.Choices,
                    Points = mcq.Points,
                    CorrectAnswer = ""
                };
              
            }
            else if (question is TrueFalseQuestion tfq)
            {
            
                return new TrueFalseQuestion
                {
                    QuestionText = tfq.QuestionText,
                    Points = tfq.Points,
                    CorrectAnswer = ""
                };
            }
            else
            {
                throw new ArgumentException("Unknown Type");
            }
           
            
        }

        public Question GetNextQuestion()
        {
            
            if(_currentQuestionIndex < _questionList.Count - 1)
            {
                _currentQuestionIndex++;
                _isAnswered = false;          
                return GetQuestionWithoutAnswer();
                
            }
            throw new InvalidOperationException("No More Questions");
        }

        public bool CheckUserAnswer(string userAnswer)
        {
            Question currentQuestion = _questionList[_currentQuestionIndex];
            if(currentQuestion.CorrectAnswer.ToLower() == userAnswer.ToLower() && !_isAnswered)
            {
                Score++;
                _isAnswered = true;
                return true;
            }
            else
            {
                _isAnswered = false;
                return false;
            }
        }

        public int GetTotalNumberOfQuestions()
        {
            return _questionList.Count;
        }


    }

	
}

