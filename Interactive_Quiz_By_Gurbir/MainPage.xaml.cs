namespace Interactive_Quiz_By_Gurbir;

public partial class MainPage : ContentPage
{
	private Quiz _quiz;
	private Question _currentQuestion;
	private bool _isAnswered;

	public MainPage()
	{
		InitializeComponent();
		_quiz = new Quiz("My quiz");
		ShowQuestion();
	}

	private void ShowQuestion()
	{
        _isAnswered = false;

		if (_quiz.Score == _quiz.GetTotalNumberOfQuestions())
		{
            quizQuestion.Text = "Congratulations, you've finished the quiz!\n\nYour final score is " + _quiz.Score + " out of " + _quiz.GetTotalNumberOfQuestions();
        }
		else
		{
            nextQuestionButton.IsVisible = true;
            nextQuestionButton.IsEnabled = true;
            _currentQuestion = _quiz.GetNextQuestion();
            quizTitle.Text = _quiz.Title;
            quizQuestion.Text = _currentQuestion.QuestionText;

            answerButton1.BackgroundColor = Colors.White;
            answerButton2.BackgroundColor = Colors.White;
            answerButton3.BackgroundColor = Colors.White;
            answerButton4.BackgroundColor = Colors.White;

        }
        
        if (_currentQuestion is TrueFalseQuestion tfq)
		{
			answerButton1.Text = "True";
			answerButton2.Text = "False";
            answerButton3.IsVisible = false;
            answerButton4.IsVisible = false;
        }
		else if(_currentQuestion is MultipleChoiceQuestion mcq)
		{
			answerButton1.Text = mcq.Choices[0];
            answerButton2.Text = mcq.Choices[1];
            answerButton3.Text = mcq.Choices[2];
            answerButton4.Text = mcq.Choices[3];
            answerButton3.IsVisible = true;
            answerButton4.IsVisible = true;
        }
		
    }

	private void OnAnswerButtonClicked(object sender, EventArgs e)
	{
		if (_isAnswered) return;
		_isAnswered = true;

		Button button = (Button)sender;
		string userAnswer = button.Text;

		bool isCorrect = _quiz.CheckUserAnswer(userAnswer);


        button.BackgroundColor = isCorrect ? Colors.Green : Colors.Red;



        


    }

	private void OnNextQuestionClicked(object sender, EventArgs e)
	{

        if (!_isAnswered) return;

        if (_quiz.Score == _quiz.GetTotalNumberOfQuestions())
        {
            DisplayScore();
            return;
        }

        ShowQuestion();

        //      Question nextQuestion = _quiz.GetNextQuestion();

        //      if (nextQuestion != null)
        //{
        //          _currentQuestion = nextQuestion;
        //          ShowQuestion();

        //      }

        //else
        //{
        //	DisplayScore();
        //}
    }

	private void OnQuitButtonClicked(object sender, EventArgs e)
	{

		DisplayScore();
        

    }

	private void DisplayScore()
	{
		int totalQuestions = _quiz.GetTotalNumberOfQuestions();
		string message = $"You got {_quiz.Score} correct answers out of {totalQuestions}";
		DisplayAlert("Quiz Score", message, "OK");
	}


}
    



