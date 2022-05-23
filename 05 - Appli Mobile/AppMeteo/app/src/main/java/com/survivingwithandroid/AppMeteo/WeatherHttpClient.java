/**
 * This is a tutorial source code 
 * provided "as is" and without warranties.
 *
 * For any question please visit the web site
 * http://www.survivingwithandroid.com
 *
 * or write an email to
 * survivingwithandroid@gmail.com
 *
 */
package com.survivingwithandroid.AppMeteo;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
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

//classe qui permet d'exécuter une requête http et de récupérer le résultat

public class WeatherHttpClient {
	//on définit une propriété pour l'url de base
	private static String BASE_URL = "http://api.openweathermap.org/data/2.5/weather?q=";
	//on définit une propriété pour la clé de l'api
	private static String KEY_API="4c751f95a60360ae52bee41672463b92";
	//on définit une propriété pour le format retourné de l'API
	private static String MODE_API="json";
	//on définit l'url pour les images
	private static String IMG_URL = "http://openweathermap.org/img/w/";
	//on définit une propriété pour l'extension des images
	private static String IMG_EXT=".png";
	//on définit une propriété pour la langue
    private static String LNG="fr";

	
	public String getWeatherData(String location,String lng) {
		HttpURLConnection con = null ;
		InputStream is = null;
		String url="";

        if (lng.equals("")) lng=LNG;
		//on construit l'url selon les propriétés que l'on a définies et les paramètres d'entrée

		url=BASE_URL + location+"&mode="+MODE_API+"&appid="+KEY_API+"&lang="+lng;
		System.out.println(url);
		try {
			con = (HttpURLConnection) ( new URL(url)).openConnection();
			con.setRequestMethod("GET");
			con.setDoInput(true);
			con.setDoOutput(false);
			con.connect();
			
			// Let's read the response
			StringBuffer buffer = new StringBuffer();
			is = con.getInputStream();
			BufferedReader br = new BufferedReader(new InputStreamReader(is));
			String line = null;
			while (  (line = br.readLine()) != null )
				buffer.append(line + "\r\n");
			
			is.close();
			con.disconnect();
            //on récupère le résultat en chaîne de caractères (ici json)
			return buffer.toString();
	    }
		catch(Throwable t) {
			t.printStackTrace();
		}
		finally {
			try { is.close(); } catch(Throwable t) {}
			try { con.disconnect(); } catch(Throwable t) {}
		}

		return null;
				
	}
	
	public byte[] getImage(String code) {


		HttpURLConnection con = null ;
		InputStream is = null;
		try {
            //on construit l'url selon les propriétés que l'on a définies et les paramètres d'entrée
			con = (HttpURLConnection) ( new URL(IMG_URL + code + IMG_EXT)).openConnection();
			con.setRequestMethod("GET");
			con.setDoInput(true);
			con.setDoOutput(false);
			con.connect();
			

			is = con.getInputStream();
			byte[] buffer = new byte[1024];
			ByteArrayOutputStream baos = new ByteArrayOutputStream();
			
			while ( is.read(buffer) != -1)
				baos.write(buffer);
			//on récupère l'image en bytes
			return baos.toByteArray();
	    }
		catch(Throwable t) {
			t.printStackTrace();
		}
		finally {
			try { is.close(); } catch(Throwable t) {}
			try { con.disconnect(); } catch(Throwable t) {}
		}
		
		return null;
		
	}
}
