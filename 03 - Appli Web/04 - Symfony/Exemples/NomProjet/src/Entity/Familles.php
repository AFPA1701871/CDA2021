<?php

namespace App\Entity;

use App\Repository\FamillesRepository;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=FamillesRepository::class)
 */
class Familles
{
    /**
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="string", length=50)
     */
    private $Patronyme;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getPatronyme(): ?string
    {
        return $this->Patronyme;
    }

    public function setPatronyme(string $Patronyme): self
    {
        $this->Patronyme = $Patronyme;

        return $this;
    }
    public function __toString()
    {
        return $this->getPatronyme();
    }

}
