<?php

namespace App\Controller;

use App\Entity\Familles;
use App\Form\FamillesType;
use App\Repository\FamillesRepository;
use Doctrine\ORM\EntityManagerInterface;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Request;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

/**
 * @Route("/familles")
 */
class FamillesController extends AbstractController
{
    /**
     * @Route("/", name="familles_index", methods={"GET"})
     */
    public function index(FamillesRepository $famillesRepository): Response
    {
        return $this->render('familles/index.html.twig', [
            'familles' => $famillesRepository->findAll(),
        ]);
    }

    /**
     * @Route("/new", name="familles_new", methods={"GET", "POST"})
     */
    public function new(Request $request, EntityManagerInterface $entityManager): Response
    {
        $famille = new Familles();
        $form = $this->createForm(FamillesType::class, $famille);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $entityManager->persist($famille);
            $entityManager->flush();

            return $this->redirectToRoute('familles_index', [], Response::HTTP_SEE_OTHER);
        }

        return $this->render('familles/new.html.twig', [
            'famille' => $famille,
            'form' => $form->createView(),
        ]);
    }

    /**
     * @Route("/{id}", name="familles_show", methods={"GET"})
     */
    public function show(Familles $famille): Response
    {
        return $this->render('familles/show.html.twig', [
            'famille' => $famille,
        ]);
    }

    /**
     * @Route("/{id}/edit", name="familles_edit", methods={"GET", "POST"})
     */
    public function edit(Request $request, Familles $famille, EntityManagerInterface $entityManager): Response
    {
        $form = $this->createForm(FamillesType::class, $famille);
        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {
            $entityManager->flush();

            return $this->redirectToRoute('familles_index', [], Response::HTTP_SEE_OTHER);
        }

        return $this->render('familles/edit.html.twig', [
            'famille' => $famille,
            'form' => $form->createView(),
        ]);
    }

    /**
     * @Route("/{id}", name="familles_delete", methods={"POST"})
     */
    public function delete(Request $request, Familles $famille, EntityManagerInterface $entityManager): Response
    {
        if ($this->isCsrfTokenValid('delete'.$famille->getId(), $request->request->get('_token'))) {
            $entityManager->remove($famille);
            $entityManager->flush();
        }

        return $this->redirectToRoute('familles_index', [], Response::HTTP_SEE_OTHER);
    }
}
