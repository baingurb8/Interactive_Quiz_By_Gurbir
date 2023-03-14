namespace Interactive_Quiz_By_Gurbir;

public partial class MainPage : ContentPage
{
	private Quiz _quiz;
	private Question _currentQuestion;
	private bool _isAnswered;

	public MainPage()
	{
		InitializeComponent();
		_quiz = new Quiz("Interactive Quiz");//creates the quiz
		ShowQuestion();//display a question to the user
	}

	private void ShowQuestion()
	{
        _isAnswered = false;//only shows the question if it has not been answered 

		if (_quiz.Score == _quiz.GetTotalNumberOfQuestions())//if user score is equal to the number if questions, game is over
		{
            quizQuestion.Text = "Congratulations, you've finished the quiz!\n\nYour final score is " + _quiz.Score + " out of " + _quiz.GetTotalNumberOfQuestions();
        }
		else//if the user score is below the total number of questions
		{
            nextQuestionButton.IsVisible = true;
            nextQuestionButton.IsEnabled = true;
            _currentQuestion = _quiz.GetNextQuestion();//gets next questions
            quizTitle.Text = _quiz.Title;
            quizQuestion.Text = _currentQuestion.QuestionText;

			//setting all buttons back to white after each question
            answerButton1.BackgroundColor = Colors.White;
            answerButton2.BackgroundColor = Colors.White;
            answerButton3.BackgroundColor = Colors.White;
            answerButton4.BackgroundColor = Colors.White;

        }
        
        if (_currentQuestion is TrueFalseQuestion tfq)//hides two answer buttons if question is t/f
		{
			answerButton1.Text = "True";
			answerButton2.Text = "False";
            answerButton3.IsVisible = false;
            answerButton4.IsVisible = false;
        }
		else if(_currentQuestion is MultipleChoiceQuestion mcq)//shows all answer buttons when question is not t/f
		{
			answerButton1.Text = mcq.Choices[0];
            answerButton2.Text = mcq.Choices[1];
            answerButton3.Text = mcq.Choices[2];
            answerButton4.Text = mcq.Choices[3];
            answerButton3.IsVisible = true;
            answerButton4.IsVisible = true;
        }
		
    }

	private void OnAnswerButton_Clicked(object sender, EventArgs e)
	{
		if (_isAnswered) return;
		_isAnswered = true;//when the question has been answered, tells the game the quesiton has been answered

		Button button = (Button)sender;
		string userAnswer = button.Text;//gives value to the user guess to whatever button they selected

		bool isCorrect = _quiz.CheckUserAnswer(userAnswer);


        button.BackgroundColor = isCorrect ? Colors.Green : Colors.Red;//if user is right the button the user has selected turns green, if incorrect, turns red
        

    }

	private void OnNextQuestion_Clicked(object sender, EventArgs e)
	{

		if (!_isAnswered) return;//prevents the user from going to the next question, without answering

		if(_quiz.Score == _quiz.GetTotalNumberOfQuestions())//if score and number of questions is equal, ends the game
		{
			DisplayScore();
			return;
		}

		ShowQuestion();//if game is not over shows next

        
    }

	private void OnQuitButton_Clicked(object sender, EventArgs e)
	{

		DisplayScore();//displays score when user quits 

    }

	private void DisplayScore()
	{
		int totalQuestions = _quiz.GetTotalNumberOfQuestions();
		string message = $"You got {_quiz.Score} correct answers out of {totalQuestions}";
		DisplayAlert("Quiz Score", message, "OK");//calculates score and displays message to user
	}


}
    



