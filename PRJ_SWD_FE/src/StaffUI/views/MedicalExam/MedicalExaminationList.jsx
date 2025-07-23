import React, { useEffect, useState } from "react";

const MedicalExaminationList = () => {
  const [exams, setExams] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("https://localhost:7012/api/medicalexamination/list")
      .then((res) => res.json())
      .then((data) => {
        setExams(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Failed to fetch:", err);
        setLoading(false);
      });
  }, []);

  const handleDelete = (id) => {
    if (!window.confirm("Are you sure you want to delete this record?")) return;

    fetch(`https://localhost:7012/api/medicalexamination/${id}`, {
      method: "DELETE",
    })
      .then((res) => {
        if (!res.ok) throw new Error("Delete failed");
        setExams(exams.filter((e) => e.meid !== id)); // hoặc refetch lại toàn bộ nếu cần
      })
      .catch((err) => console.error(err));
  };

  const handleDetail = (id) => {
    window.location.href = `/medical-examinations/${id}`;
  };

  const handleEdit = (id) => {
    window.location.href = `/medical-examinations/edit/${id}`;
  };

  const handleCreate = () => {
    window.location.href = "/medical-examinations/create";
  };

  if (loading) return <p>Loading...</p>;

  return (
    <div>
      <h2>Medical Examination List</h2>
      <button onClick={handleCreate}>+ Create</button>
      <br /><br />
      <table border="1" cellPadding="8">
        <thead>
          <tr>
            <th>ID</th>
            <th>Customer</th>
            <th>Staff</th>
            <th>Date</th>
            <th>Symptoms</th>
            <th>Diagnosis</th>
            <th>Fee</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {exams.map((e) => (
            <tr key={e.meid}>
              <td>{e.meid}</td>
              <td>{e.customerName}</td>
              <td>{e.staffName}</td>
              <td>{e.examinationDate}</td>
              <td>{e.symptoms}</td>
              <td>{e.diagnosis}</td>
              <td>{e.examinationFee}</td>
              <td>
                <button onClick={() => handleDetail(e.meid)}>Detail</button>{" "}
                <button onClick={() => handleEdit(e.meid)}>Edit</button>{" "}
                <button onClick={() => handleDelete(e.meid)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default MedicalExaminationList;
