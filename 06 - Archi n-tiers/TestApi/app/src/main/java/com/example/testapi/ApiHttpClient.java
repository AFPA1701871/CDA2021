package com.example.testapi;

import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class ApiHttpClient {
    //on définit une propriété pour l'url de base
    private static String BASE_URL = "http://10.115.41.56:5001/api/Personnes/";


    public String getData(String idPersonne) {
        HttpURLConnection con = null ;
        InputStream is = null;
        String url="";
        int responseCode ;
        StringBuffer buffer = new StringBuffer();

        // On ajoute l'idPersonne à l'url, s'il y a pas d'id, on ramène la liste
        url=BASE_URL + idPersonne;
        Log.d("Test", "URL: "+url);
        try {
            // on établit la connection
            con = (HttpURLConnection) ( new URL(url)).openConnection();
            con.setRequestMethod("GET");
            con.setDoInput(true);
            con.setDoOutput(false);
            con.connect();

            // en fonction du code réponse, on récupère les données ou l'erreur
            responseCode = con.getResponseCode();
            if (200 <= responseCode && responseCode <= 299) {
                is = con.getInputStream();
            } else {
                is = con.getErrorStream();
            }
            // Let's read the response
            BufferedReader br = new BufferedReader(new InputStreamReader(is));
            String line = null;
            while (  (line = br.readLine()) != null )
                buffer.append(line + "\r\n");

            // on ferme la connection
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
}
