from flask import Flask, render_template
import requests

app = Flask(__name__)

@app.route('/')
def index():

    url_heroes = "https://api.opendota.com/api/heroes"
    heroes_data = requests.get(url_heroes).json()
    

    url_matches = "https://api.opendota.com/api/proMatches"
    matches_data = requests.get(url_matches).json()


    return render_template('index.html', heroes=heroes_data, matches=matches_data)

if __name__ == '__main__':
    app.run(debug=True)
