import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Reservation from "../views/Reservation/Reservation";
import Blog from "../views/Blog/Blog"; 
import BlogDetail from '../views/Blog/BlogDetail';
import BlogCreate from '../views/Blog/BlogCreate';
import BlogUpdate from '../views/Blog/BlogUpdate';
import ReservationCreate from '../views/Reservation/ReservationCreate';
import ReservationDetail from "../views/Reservation/ReservationDetail";
import ReservationUpdate from "../views/Reservation/ReservationUpdate";
import Service from "../views/Service/Service";
import ServiceCreate from "../views/Service/ServiceCreate";
import ServiceEdit from "../views/Service/ServiceEdit";
import ServiceDetail from "../views/Service/ServiceDetail";
import MedicalExaminationList from '../views/MedicalExam/MedicalExaminationList';
import MedicalExaminationForm from '../views/MedicalExam/MedicalExaminationForm';
import MedicalExaminationDetail from '../views/MedicalExam/MedicalExaminationDetail';

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/reservation" />} />
      <Route path="/reservation" element={<Reservation />} />
      <Route path="/blog" element={<Blog />} />
      <Route path="/blog/detail/:id" element={<BlogDetail />} />
      <Route path="/blog/create" element={<BlogCreate/>} />
      <Route path="/blog/edit/:id" element={<BlogUpdate/>} />
      <Route path="/reservation/create" element={<ReservationCreate />} />
      <Route path="/reservation/detail/:id" element={<ReservationDetail />} />
      <Route path="/reservation/edit/:id" element={<ReservationUpdate />} /> 
      <Route path="/service" element={<Service />} />
      <Route path="/service/create" element={<ServiceCreate />} />
      <Route path="/service/edit/:id" element={<ServiceEdit />} />
      <Route path="/service/detail/:id" element={<ServiceDetail />} />
      <Route path="/medical-examinations" element={<MedicalExaminationList />} />
      <Route path="/medical-examinations/create" element={<MedicalExaminationForm />} />
      <Route path="/medical-examinations/edit/:id" element={<MedicalExaminationForm />} />
      <Route path="/medical-examinations/:id" element={<MedicalExaminationDetail />} />

    </Routes>
  );
};

export default AppRoutes;