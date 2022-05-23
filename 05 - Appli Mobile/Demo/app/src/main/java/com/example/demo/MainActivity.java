package com.example.demo;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.media.TimedText;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

     private EditText valeur;
    private EditText nom;
    private TextView reponse;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Intent intent = new Intent(this, Activity2.class);
        valeur = (EditText) findViewById(R.id.eTValeur);
        nom = (EditText) findViewById(R.id.eTNom);
        reponse  = (TextView) findViewById(R.id.reponse);
        Button bouton = (Button) findViewById(R.id.button);
        bouton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                 intent.putExtra("age", valeur.getText().toString());
                intent.putExtra("nom", nom.getText().toString());
                startActivity(intent);
            }
        });

        Intent inReponse = getIntent();
        Log.d("**********debug", "intent: " + inReponse);
        if ( inReponse != null)
        {
            String nom2 = inReponse.getStringExtra("nom2");
            Integer age2 =  inReponse.getIntExtra("age2",0);
             reponse.setText( nom2+ " a " +age2.toString() + " ans");
             valeur.setText(age2.toString());
             nom.setText(nom2);
        }
    }

}