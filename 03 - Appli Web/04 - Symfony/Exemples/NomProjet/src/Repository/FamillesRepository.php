<?php

namespace App\Repository;

use App\Entity\Familles;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @method Familles|null find($id, $lockMode = null, $lockVersion = null)
 * @method Familles|null findOneBy(array $criteria, array $orderBy = null)
 * @method Familles[]    findAll()
 * @method Familles[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class FamillesRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, Familles::class);
    }

    // /**
    //  * @return Familles[] Returns an array of Familles objects
    //  */
    /*
    public function findByExampleField($value)
    {
        return $this->createQueryBuilder('f')
            ->andWhere('f.exampleField = :val')
            ->setParameter('val', $value)
            ->orderBy('f.id', 'ASC')
            ->setMaxResults(10)
            ->getQuery()
            ->getResult()
        ;
    }
    */

    /*
    public function findOneBySomeField($value): ?Familles
    {
        return $this->createQueryBuilder('f')
            ->andWhere('f.exampleField = :val')
            ->setParameter('val', $value)
            ->getQuery()
            ->getOneOrNullResult()
        ;
    }
    */
}
