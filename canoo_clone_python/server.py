from flask import Flask, render_template, request, redirect
from flask_mail import Mail, Message
app = Flask(__name__)

app.config['MAIL_SERVER'] = 'smtp.gmail.com'
app.config['MAIL_PORT'] = 465
app.config['MAIL_USE_TLS'] = False
app.config['MAIL_USE_SSL'] = True
app.config['MAIL_DEBUG'] = True
app.config['MAIL_USERNAME'] = None
app.config['MAIL_PASSWORD'] = '' #change to fit sender
app.config['MAIL_DEFAULT_SENDER'] = 'brianjosephkeener@gmail.com'
app.config['MAIL_MAX_EMAIL'] = None
app.config['MAIL_SUPPRESS_SEND'] = False
app.config['MAIL_ASCII_ATTACHMENTS'] = False


mail = Mail(app)

@app.route('/')          
def index():
    return render_template('index.html')

@app.route('/leadgen', methods=['POST'])
def create_email():
    print("RECEIVED FORM")
    subOfI = request.form['email']
    msg = Message("You signed up for the Fake Canoo Newsletter!", recipients=[f'{subOfI}'])
    mail.send(msg)
    return redirect('/')


if __name__=="__main__":      
    app.run(debug=True)   

