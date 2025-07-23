import React from "react";
import { Route } from "react-router-dom";
import Medicine from "../views/Medicine/Medicine";
import MedicineCreate from "../views/Medicine/MedicineCreate"
import MedicineEdit from "../views/Medicine/MedicineEdit"
import MedicineDetail from "../views/Medicine/MedicineDetail"
import Prescription from "../views/Prescription/Prescription"
import PrescriptionCreate from "../views/Prescription/PrescriptionCreate"
import PrescriptionEdit from "../views/Prescription/PrescriptionEdit";
import PrescriptionDetail from "../views/Prescription/PrescriptionDetail";
import MedicalExaminationList from '../views/MedicalExam/MedicalExaminationList';
import MedicalExaminationForm from '../views/MedicalExam/MedicalExaminationForm';
import MedicalExaminationDetail from '../views/MedicalExam/MedicalExaminationDetail';

const staffRoutes = [
  <Route key="medicine" path="/medicine" element={<Medicine />} />,
  <Route key="medicine-create" path="/medicine/create" element={<MedicineCreate />} />,
  <Route key="medicine-edit" path="/medicine/edit/:id" element={<MedicineEdit />} />,
  <Route key="medicine-detail" path="/medicine/detail/:id" element={<MedicineDetail />} />,
  <Route key="prescription" path="/prescription" element={<Prescription />} />,
  <Route key="prescription-create" path="/prescription/create" element={<PrescriptionCreate />} />,
  <Route key="prescription-edit" path="/prescription/edit/:id" element={<PrescriptionEdit />} />,
  <Route key="prescription-detail" path="/prescription/detail/:id" element={<PrescriptionDetail />} />,
  <Route path="/medical-examinations" element={<MedicalExaminationList />} />,
  <Route path="/medical-examinations/create" element={<MedicalExaminationForm />} />,
  <Route path="/medical-examinations/edit/:id" element={<MedicalExaminationForm />} />,
  <Route path="/medical-examinations/:id" element={<MedicalExaminationDetail />} />,
];

export default staffRoutes;
