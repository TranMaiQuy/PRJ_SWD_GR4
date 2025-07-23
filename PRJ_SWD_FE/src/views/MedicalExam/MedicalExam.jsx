import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

function MedicalExamination() {
  const [examinations, setExaminations] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5001/api/medicalexaminations')
      .then(res => setExaminations(res.data))
      .catch(err => console.error(err));
  }, []);

  return (
    <div className="container mt-4">
      <div className="d-flex justify-content-between align-items-center mb-3">
        <h2>Medical Examinations</h2>
        <Link className="btn btn-success" to="/medical-examinations/create">Create</Link>
      </div>
      <table className="table table-bordered table-striped">
        <thead>
          <tr>
            <th>ID</th>
            <th>Reservation ID</th>
            <th>Date</th>
            <th>Symptoms</th>
            <th>Diagnosis</th>
            <th>Notes</th>
            <th>Fee</th>
            <th>Staff ID</th>
            <th>Customer ID</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {examinations.map(exam => (
            <tr key={exam.meid}>
              <td>{exam.meid}</td>
              <td>{exam.reservationId}</td>
              <td>{exam.examinationDate}</td>
              <td>{exam.symptoms}</td>
              <td>{exam.diagnosis}</td>
              <td>{exam.notes}</td>
              <td>{exam.examinationFee}</td>
              <td>{exam.staffId}</td>
              <td>{exam.customerId}</td>
              <td>
                <Link className="btn btn-primary btn-sm me-2" to={`/medical-examinations/edit/${exam.meid}`}>Edit</Link>
                <Link className="btn btn-secondary btn-sm me-2" to={`/medical-examinations/detail/${exam.meid}`}>Details</Link>
                <Link className="btn btn-danger btn-sm" to={`/medical-examinations/delete/${exam.meid}`}>Delete</Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default MedicalExamination;
