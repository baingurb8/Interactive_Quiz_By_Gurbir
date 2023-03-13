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


    }

	
}

