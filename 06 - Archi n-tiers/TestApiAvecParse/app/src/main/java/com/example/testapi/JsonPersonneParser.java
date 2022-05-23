package com.example.testapi;

import org.json.JSONException;
import org.json.JSONObject;

public class JsonPersonneParser {
    public static Personnes parsePersonne(String json) throws JSONException{
        Personnes perso = new Personnes();
        try {
            JSONObject jObj = new JSONObject(json);
            perso.setIdPersonne(jObj.getInt("idPersonne"));
            perso.setNom(jObj.getString("nom"));
            perso.setPrenom(jObj.getString("prenom"));
        }
        catch (Exception e){}
        return  perso;
    }
}
