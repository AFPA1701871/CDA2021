package com.example.demo;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class Activity2 extends AppCompatActivity {

    private TextView resultat;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_2);
        
        resultat = (TextView) findViewById(R.id.resultat);
        Button retour = (Button) findViewById(R.id.retour);
        Intent inRetour = new Intent(this,MainActivity.class);

        Intent intentReception=getIntent();
        String valeur =  intentReception.getStringExtra("age");
        String nom =  intentReception.getStringExtra("nom");
        resultat.setText(nom +" a " + valeur+" ans");

        retour.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Integer newAge = Integer.parseInt(valeur)+1;
                inRetour.putExtra("age2",newAge);
                inRetour.putExtra("nom2",nom);
                startActivity(inRetour);
            }
        });
    }
}