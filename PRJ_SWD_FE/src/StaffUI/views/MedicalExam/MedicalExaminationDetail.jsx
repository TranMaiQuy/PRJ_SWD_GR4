import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

const MedicalExaminationDetail = () => {
  const { id } = useParams();
  const [exam, setExam] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    fetch(`https://localhost:7012/api/medicalexamination/${id}`)
      .then((res) => res.json())
      .then((data) => setExam(data));
  }, [id]);

  if (!exam) return <p>Loading...</p>;

  return (
    <div>
      <h2>Medical Examination Detail</h2>
      <ul>
        <li><strong>ID:</strong> {exam.meid}</li>
        <li><strong>Reservation ID:</strong> {exam.reservationId}</li>
        <li><strong>Examination Date:</strong> {exam.examinationDate}</li>
        <li><strong>Symptoms:</strong> {exam.symptoms}</li>
        <li><strong>Diagnosis:</strong> {exam.diagnosis}</li>
        <li><strong>Notes:</strong> {exam.notes}</li>
        <li><strong>Fee:</strong> {exam.examinationFee}</li>
        <li><strong>Staff ID:</strong> {exam.staffId}</li>
        <li><strong>Customer ID:</strong> {exam.customerId}</li>
      </ul>
      <button onClick={() => navigate("/medical-examinations")}>Back to List</button>
    </div>
  );
};

export default MedicalExaminationDetail;
