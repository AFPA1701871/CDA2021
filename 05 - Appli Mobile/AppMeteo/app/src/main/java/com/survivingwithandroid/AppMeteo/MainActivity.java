package com.survivingwithandroid.AppMeteo;

import org.json.JSONException;
import com.survivingwithandroid.AppMeteo.model.Weather;
import android.content.Context;
import android.content.res.Configuration;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Locale;

import android.view.inputmethod.InputMethodManager;


/*
 * Copyright (C) 2013 Surviving with Android (http://www.survivingwithandroid.com)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

public class MainActivity extends Activity {

	//On déclare tous les contrôles de l'activité
	private TextView cityText;
	private TextView condDescr;
	private TextView humLab;
	private TextView pressLab;
	private TextView windLab;
    private TextView temp;
    private TextView press;
    private TextView windSpeed;
	private EditText txtSearch;
	private TextView hum;
	private ImageView imgView;
    private Button btnSearch;
    //variable de stockage du texte recherché
    private String stringSearch;


	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		txtSearch=(EditText) findViewById(R.id.txtSearch);
        //on initialise la zone de recherche à vide
		txtSearch.setText("");

        //affectation de tous les contrôles de l'activité
		cityText = (TextView) findViewById(R.id.cityText);
		condDescr = (TextView) findViewById(R.id.condDescr);
		temp = (TextView) findViewById(R.id.temp);
		hum = (TextView) findViewById(R.id.hum);
		press = (TextView) findViewById(R.id.press);
		windSpeed = (TextView) findViewById(R.id.windSpeed);
		imgView = (ImageView) findViewById(R.id.condIcon);
        humLab = (TextView) findViewById(R.id.humLab);
        pressLab = (TextView) findViewById(R.id.pressLab);
        windLab = (TextView) findViewById(R.id.windLab);
        btnSearch=(Button) findViewById(R.id.btnSearch);

        //on rend non visibles les textview d'affichage de résultat
        humLab.setVisibility(View.GONE);
        pressLab.setVisibility(View.GONE);
        windLab.setVisibility(View.GONE);

	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// on génère l'affichage d'un menu grâce au MenuInflater
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
        //Quand on sélectionne l'une ou l'autre des langues disponibles de l'application
        //on change la configuration de l'application selon la langue choisie
        Configuration conf = new Configuration();
        //on sauvegarde le texte recherché qui a été éventuellement saisi en mémoire
        stringSearch=txtSearch.getText().toString();
        //on compare l'identifiant du contrôle donné par rapport à ce qui a été sélectionné
        switch (item.getItemId()) {
			case R.id.action_gb:
                //on met à jour la configuration pour l'anglais
                conf.locale = Locale.ENGLISH;
                Locale.setDefault(conf.locale);
                getBaseContext().getResources().updateConfiguration(conf, getBaseContext().getResources().getDisplayMetrics());
                //on recrée l'activité pour actualiser l'affichage
                onCreate(null);
                //on met à jour le nom de l'application
                setTitle(getResources().getString(R.string.app_name));
                //on réaffecte le tete recherché conservé en mémoire dans la zone de texte
                txtSearch.setText(stringSearch);
                //on redonne le focus à la zone de recherche
                txtSearch.requestFocus();
                //on exécute la recherche
                sendRequest(btnSearch);
				return true;
			case R.id.action_fr:
                //on met à jour la configuration pour le français
                conf.locale = Locale.FRENCH;
                Locale.setDefault(conf.locale);
                getBaseContext().getResources().updateConfiguration(conf, getBaseContext().getResources().getDisplayMetrics());
                //on recrée l'activité pour actualiser l'affichage
                onCreate(null);
                //on réaffecte le tete recherché conservé en mémoire dans la zone de texte
                setTitle(getResources().getString(R.string.app_name));
                txtSearch.setText(stringSearch);
                //on redonne le focus à la zone de recherche
                txtSearch.requestFocus();
                //on exécute la recherche
                sendRequest(btnSearch);
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
	}


    //méthode qui vérifie si le réseau est disponible
	private Boolean isNetworkAvailable() {
		ConnectivityManager connectivityManager
				= (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
		NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
		return activeNetworkInfo != null && activeNetworkInfo.isConnectedOrConnecting();
	}

    //méthode de vérification si internet est disponible
    public Boolean isOnline() {
        try {
            Process p1 = java.lang.Runtime.getRuntime().exec("ping -c 1 www.google.com");
            int returnVal = p1.waitFor();
            boolean reachable = (returnVal==0);
            return reachable;
        } catch (Exception e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        return false;
    }

	/** Lancement de la recherche */
	public void sendRequest(View view) {

		InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);

        if (isNetworkAvailable()) {
            if (isOnline()) {
                if (!txtSearch.getText().toString().trim().equals("")) {
                    txtSearch.setText(txtSearch.getText().toString().trim());
                    txtSearch.setSelection(txtSearch.getText().length());
                    imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
                    //si la zone de recherche est remplie, on lance une tâche asynchrone en fonction de la saisie et de la langue
                    JSONWeatherTask task = new JSONWeatherTask();
                    task.execute(txtSearch.getText().toString(), Locale.getDefault().getLanguage());

                } else {
                    txtSearch.requestFocus();
                }
            } else {
                Toast.makeText(view.getContext(),getApplicationContext().getResources().getString(R.string.no_online),Toast.LENGTH_LONG);
            }
        } else {
            Toast.makeText(view.getContext(),getApplicationContext().getResources().getString(R.string.no_network),Toast.LENGTH_LONG);
        }
	}


	private class JSONWeatherTask extends AsyncTask<String, Void, Weather> {

		@Override
		protected Weather doInBackground(String... params) {
            //la requête doit nous retourner un objet weather
			Weather weather = new Weather();
            String data ="";

            if (!params[0].equals("")) {
                //exécution de la requête http avec en paramètres le texte saisi et la langue
                data = ((new WeatherHttpClient()).getWeatherData(params[0], params[1]));
                if (data!=null) {
                    try {
                        //on récupère l'objet weather après traitement du json retourné
                        weather = JSONWeatherParser.getWeather(data);

                        // on exécute une nouvelle requête http pour récupérer l'icône correspondant au temps actuel
                        weather.iconData = ((new WeatherHttpClient()).getImage(weather.currentCondition.getIcon()));

                    } catch (JSONException e) {
                        e.printStackTrace();
                    }

			    return weather;
            }
            else
                {
                return null;
            }

        } else return null;
		
	}
		
		
		
		
	@Override
		protected void onPostExecute(Weather weather) {			
			super.onPostExecute(weather);
            //si l'objet retourné n'est pas null on affiche le résultat
            if (weather!=null) {

                if (weather.iconData != null && weather.iconData.length > 0) {
                    Bitmap img = BitmapFactory.decodeByteArray(weather.iconData, 0, weather.iconData.length);
                    imgView.setImageBitmap(img);
                }

                cityText.setText(weather.location.getCity() + "," + weather.location.getCountry());
                condDescr.setText(weather.currentCondition.getCondition() + "(" + weather.currentCondition.getDescr() + ")");
                temp.setText("" + Math.round((weather.temperature.getTemp() - 273.15)) + "°C");
                hum.setText("" + weather.currentCondition.getHumidity() + "%");
                press.setText("" + weather.currentCondition.getPressure() + " hPa");
                windSpeed.setText("" + weather.wind.getSpeed() + " mps");
                //si on dispose de données on rend visible les "labels"
                humLab.setVisibility(View.VISIBLE);
                pressLab.setVisibility(View.VISIBLE);
                windLab.setVisibility(View.VISIBLE);
            } else {
                cityText.setText(R.string.notFound);
                //si on ne dispose pas de données on rend invisible les "labels"
                humLab.setVisibility(View.GONE);
                pressLab.setVisibility(View.GONE);
                windLab.setVisibility(View.GONE);

            }
		}

	
  }
}
