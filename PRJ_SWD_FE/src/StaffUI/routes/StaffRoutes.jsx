import React from "react";
import { Route } from "react-router-dom";
import Medicine from "../views/Medicine/Medicine";
import MedicineCreate from "../views/Medicine/MedicineCreate"
import MedicineEdit from "../views/Medicine/MedicineEdit"
import MedicineDetail from "../views/Medicine/MedicineDetail"

const staffRoutes = [
  <Route key="medicine" path="/medicine" element={<Medicine />} />,
  <Route key="medicine-create" path="/medicine/create" element={<MedicineCreate />} />,
  <Route key="medicine-edit" path="/medicine/edit/:id" element={<MedicineEdit />} />,
  <Route key="medicine-detail" path="/medicine/detail/:id" element={<MedicineDetail />} />,
];

export default staffRoutes;
