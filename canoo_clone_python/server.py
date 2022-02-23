from crypt import methods
from flask import Flask, render_template, request, redirect
app = Flask(__name__)

@app.route('/')          
def home_page():
    return render_template('index.html')

@app.route('/leadgen', methods=['POST'])
def create_email():
    print("TEST RECEIVED FORM")
    print(request.form['fname'])
    return redirect('/')


if __name__=="__main__":      
    app.run(debug=True)   

