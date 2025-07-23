import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

const MedicalExaminationForm = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const isEdit = !!id;

  const [formData, setFormData] = useState({
    reservationId: 0,
    examinationDate: "",
    symptoms: "",
    diagnosis: "",
    notes: "",
    examinationFee: 0,
    staffId: 0,
    customerId: 0,
  });

  useEffect(() => {
    if (isEdit) {
      fetch(`https://localhost:7012/api/medicalexamination/${id}`)
        .then((res) => res.json())
        .then((data) => {
          setFormData({
            reservationId: data.reservationId,
            examinationDate: data.examinationDate,
            symptoms: data.symptoms,
            diagnosis: data.diagnosis,
            notes: data.notes,
            examinationFee: data.examinationFee,
            staffId: data.staffId,
            customerId: data.customerId,
          });
        });
    }
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const payload = {
      ...formData,
      examinationDate: formData.examinationDate,
    };

    const url = isEdit
      ? `https://localhost:7012/api/medicalexamination/${id}`
      : "https://localhost:7012/api/medicalexamination";

    const method = isEdit ? "PUT" : "POST";

    const res = await fetch(url, {
      method,
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(isEdit ? { ...payload, meid: parseInt(id) } : payload),
    });

    if (res.ok) {
      alert(`${isEdit ? "Updated" : "Created"} successfully`);
      navigate("/medical-examinations");
    } else {
      alert("Failed");
    }
  };

  return (
    <div style={styles.container}>
      <h2>{isEdit ? "Edit" : "Create"} Medical Examination</h2>
      <form onSubmit={handleSubmit} style={styles.form}>
        {[
          { label: "Reservation ID", name: "reservationId", type: "number" },
          { label: "Examination Date", name: "examinationDate", type: "date" },
          { label: "Symptoms", name: "symptoms", type: "text" },
          { label: "Diagnosis", name: "diagnosis", type: "text" },
          { label: "Notes", name: "notes", type: "textarea" },
          { label: "Examination Fee", name: "examinationFee", type: "number" },
          { label: "Staff ID", name: "staffId", type: "number" },
          { label: "Customer ID", name: "customerId", type: "number" },
        ].map((field) => (
          <div key={field.name} style={styles.field}>
            <label style={styles.label}>{field.label}:</label>
            {field.type === "textarea" ? (
              <textarea
                name={field.name}
                value={formData[field.name]}
                onChange={handleChange}
                required
                style={styles.input}
              />
            ) : (
              <input
                type={field.type}
                name={field.name}
                value={formData[field.name]}
                onChange={handleChange}
                required
                style={styles.input}
              />
            )}
          </div>
        ))}
        <button type="submit" style={styles.button}>
          {isEdit ? "Update" : "Create"}
        </button>
      </form>
    </div>
  );
};

const styles = {
  container: {
    maxWidth: "600px",
    margin: "40px auto",
    padding: "30px",
    border: "1px solid #ccc",
    borderRadius: "8px",
    boxShadow: "0 0 10px rgba(0,0,0,0.1)",
    backgroundColor: "#fff",
    fontFamily: "Arial, sans-serif",
  },
  form: {
    display: "flex",
    flexDirection: "column",
  },
  field: {
    marginBottom: "15px",
  },
  label: {
    fontWeight: "bold",
    marginBottom: "5px",
    display: "block",
  },
  input: {
    width: "100%",
    padding: "8px",
    fontSize: "14px",
    borderRadius: "4px",
    border: "1px solid #ccc",
  },
  button: {
    padding: "10px 20px",
    fontSize: "16px",
    backgroundColor: "#4CAF50",
    color: "#fff",
    border: "none",
    borderRadius: "4px",
    cursor: "pointer",
    marginTop: "10px",
  },
};

export default MedicalExaminationForm;
