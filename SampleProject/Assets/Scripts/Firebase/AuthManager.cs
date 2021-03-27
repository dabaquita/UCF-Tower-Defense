using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

using Firebase;
using Firebase.Auth;
using Firebase.Functions;


public class User
{
    public string username;
    public int currentLevel;
    public int highestWave;
    public Dictionary<string, bool> unlockedMaps;

    public User(string name)
    {
        username = name;
    }
}


public class AuthManager : MonoBehaviour
{

    //Firebase variables
    [Header("Firebase")]

    public DependencyStatus dependencyStatus;

    public FirebaseAuth auth;
    public FirebaseFunctions functions;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public GameObject loginGroup;
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text errorLoginText;

    //Register variables
    [Header("Register")]
    public GameObject signupGroup;
    public TMP_InputField usernameField;
    public TMP_InputField emailSignupField;
    public TMP_InputField passwordSignupField;
    public TMP_InputField passwordSignupVerifyField;
    public TMP_Text errorSignupText;

    [Header("Main Menu")]
    public GameObject loginButton;
    public TMP_Text usernameLabel;

    private bool showLogin = true;

    public static User currentUser = null;

    public bool updateUI = false;

    void Update()
    {
        if (updateUI)
        {
            updateUI = false;
            if (usernameLabel != null && loginButton != null)
            {

                //If the user isn't signed in show the login button otherwise show the username
                bool isSignedIn = AuthManager.currentUser != null;
                usernameLabel.enabled = isSignedIn;
                usernameLabel.text = $"Welcome back, {AuthManager.currentUser.username}!";
                loginButton.SetActive(!isSignedIn);
            }
        }
    }

    void Awake()
    {

        if (signupGroup != null)
        {
            signupGroup.SetActive(false);
        }

        if (AuthManager.currentUser != null)
        {
            bool isSignedIn = AuthManager.currentUser != null;
            if (usernameLabel != null && loginButton != null)
            {
                Debug.LogError(isSignedIn);
                usernameLabel.enabled = isSignedIn;
                loginButton.SetActive(!isSignedIn);
            }
        }
        else
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
                    {
                        dependencyStatus = task.Result;

                        if (dependencyStatus == DependencyStatus.Available)
                        {
                            auth = FirebaseAuth.DefaultInstance;
                            functions = FirebaseFunctions.DefaultInstance;

                            //Setup user if already signed in
                            if (auth.CurrentUser != null)
                            {
                                AuthManager.currentUser = new User(auth.CurrentUser.DisplayName);
                                updateUI = true;
                            }

                            // CloudFunctions.SetHighestWave(100);
                            // CloudFunctions.UnlockMap(MapName.BounceHouse);
                        }
                        else
                        {
                            Debug.LogError("Missing Firebase Dependencies: " + dependencyStatus);
                        }
                    });
        }


    }

    //MARK: Login Functionality

    public void LoginButton()
    {
        string email = emailLoginField.text;
        string password = passwordLoginField.text;
        StartCoroutine(Login(email, password));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            errorLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            errorLoginText.text = "";
            errorLoginText.text = "Logged In";

            SceneManager.LoadScene(sceneName: "MenuScene");
        }
    }

    //MARK: Signup Functionality

    //MARK: Signup Functionality

    // public void SignupButton() {
    //     string email = emailRegisterField.text;
    //     string password = passwordRegisterField.text;
    //     string passwordVerify = passwordRegisterVerifyField.text;
    //     StartCoroutine(Signup(email, password, passwordVerify));
    // }

    //MARK: Signup Functionality

    public void ToggleMode()
    {
        showLogin = !showLogin;

        loginGroup.SetActive(showLogin);
        signupGroup.SetActive(!showLogin);
        // loginGroup.GetComponent<CanvasGroup>().alpha = showLogin ? 1.0f : 0.0f;
        // signupGroup.GetComponent<CanvasGroup>().alpha = showLogin ? 0.0f : 1.0f;
    }

    public void SignupButton()
    {
        string username = usernameField.text;
        string email = emailSignupField.text;
        string password = passwordSignupField.text;
        string passwordVerify = passwordSignupVerifyField.text;
        StartCoroutine(Signup(username, email, password, passwordVerify));
    }

    private Task<string> signupTask(string email, string password, string username)
    {
        // Create the arguments to the callable function.
        var data = new Dictionary<string, object>();
        data["username"] = username;
        data["email"] = email;
        data["password"] = password;
        // Call the function and extract the operation from the result.
        var function = functions.GetHttpsCallable("createUser");
        return function.CallAsync(data).ContinueWith((task) =>
        {
            // return (string) task.Result.Data;
            return "Done";
        });
    }

    private void resetFields()
    {
        errorLoginText.text = "";
        emailLoginField.text = "";
        passwordLoginField.text = "";
        usernameField.text = "";
        emailSignupField.text = "";
        passwordSignupField.text = "";
        passwordSignupVerifyField.text = "";

    }


    private IEnumerator Signup(string username, string email, string password, string passwordVerify)
    {

        if (email == "")
        {
            errorSignupText.text = "Missing Username";
        }
        else if (passwordSignupField.text != passwordSignupVerifyField.text)
        {
            errorSignupText.text = "Password Does Not Match!";
        }
        else
        {
            var task = signupTask(email, password, username);

            yield return new WaitUntil(predicate: () => task.IsCompleted);

            if (task.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {task.Exception}");
                errorSignupText.text = $"Error: {task.Exception}";
            }
            else
            {
                Debug.LogWarning(message: "Registration successful");
                resetFields();
                ToggleMode();
            }
        }
    }
}
