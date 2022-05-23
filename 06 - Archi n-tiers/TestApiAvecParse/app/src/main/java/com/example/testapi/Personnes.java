package com.example.testapi;

public class Personnes {

    private Integer idPersonne;
    private String nom;
    private String prenom;

    public Personnes() {
    }

    public Personnes(Integer idPersonne, String nom, String prenom) {
        this.idPersonne = idPersonne;
        this.nom = nom;
        this.prenom = prenom;
    }
    public Integer getIdPersonne() {
        return idPersonne;
    }

    public void setIdPersonne(Integer idPersonne) {
        this.idPersonne = idPersonne;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getPrenom() {
        return prenom;
    }

    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }
}
