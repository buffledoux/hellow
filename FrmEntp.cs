using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TIGRE
{
	/// <summary>
	/// Description résumée de FrmEntp.
	/// </summary>
	public class FrmEntp : System.Windows.Forms.Form,IFormulaireTigre,IRechercheEntreprise
	{
		private Font fontGras;
		private Font fontNormal;
		private CFormulaireTigre comportement;
		private ModeFormulaire mode = ModeFormulaire.Creation;

		private int codeEntreprise = 0;
		private int codeAdresse = 0;
		private int codeDateOuverture = 0;
		private int codeDateFermeture = 0;
		private int codeTel = 0;
		private int codeFax = 0;
		private int codeTel24 = 0;
		private int codeMel = 0;
		private int codeUrl = 0;
		private string strAncienID;
		private int codeSecteur = 0;
		private int codeResponsable = 0;

		private bool _existante = false;
		private bool _modifie = false;
		private bool _modifieID = false;
		private bool _modifieAdresse = false;
		private bool _modifieComm = false;
		private bool _modifieSecteur = false;

		private int[] messageStatut;
		private DataTable dtValidation;
		private DataTable dtHistorique;
        private Control[] ChampsSecteur;

		#region Contrôles

		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtMel;
		private System.Windows.Forms.TextBox txtFax;
		private System.Windows.Forms.TextBox txtTel;
		private System.Windows.Forms.TextBox txtNom;
		private System.Windows.Forms.TextBox txtSIREN;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button butFermer;
		private System.Windows.Forms.ComboBox cmbFJ;
		private System.Windows.Forms.Label lblNom;
		private System.Windows.Forms.Label lblEntp;
		private System.Windows.Forms.Label lblSIREN;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblFJ;
		private System.Windows.Forms.TextBox txtAdr1Siege;
		private System.Windows.Forms.TextBox txtAdr2Siege;
		private System.Windows.Forms.Label lblAdr1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lblMetier;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel11;
        private ComboBoxEx cmbTypeEnt;
		private System.Windows.Forms.Panel panel24;
		private System.Windows.Forms.Panel panel25;
		private System.Windows.Forms.Panel panel26;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Panel panel27;
		private System.Windows.Forms.Panel panEL;
		private System.Windows.Forms.Panel panel32;
		private System.Windows.Forms.Panel panel33;
		private System.Windows.Forms.Panel panel34;
		private System.Windows.Forms.Panel panel35;
		private System.Windows.Forms.TextBox textBox32;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox textBox35;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox textBox36;
		private System.Windows.Forms.Button butAdresse;
		private System.Windows.Forms.Button butSupprimer;
		private System.Windows.Forms.Button butSauver;
		private System.Windows.Forms.Button butNouveau;
        private System.Windows.Forms.Button butCommunication;
		private System.Windows.Forms.Button butSousTraitant;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox33;
		private System.Windows.Forms.Panel panel36;
		private System.Windows.Forms.Panel panel37;
		private System.Windows.Forms.Panel panel38;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Panel panel39;
		private System.Windows.Forms.TextBox textBox34;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TextBox textBox37;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel40;
		private System.Windows.Forms.RadioButton rbAdresseFrance;
		private System.Windows.Forms.RadioButton rbAdresseEtranger;
		private System.Windows.Forms.Panel panAdresse3;
		private System.Windows.Forms.Label lblVille;
		private System.Windows.Forms.Panel panCedexSiege;
		private System.Windows.Forms.Label lblCedexSiege;
		private System.Windows.Forms.TextBox txtCedexSiege;
		private System.Windows.Forms.Button butCompletion;
		private System.Windows.Forms.TextBox txtCPSiege;
		private System.Windows.Forms.TextBox txtVilleSiege;
        private System.Windows.Forms.Label lblCP;
		private System.Windows.Forms.Label label25;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList ilsTypeEnt;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtKbis;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.ToolTip infobulle;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Panel panel20;
		private System.Windows.Forms.Panel panel54;
		private System.Windows.Forms.Panel panel55;
		private System.Windows.Forms.Panel panel56;
		private System.Windows.Forms.Panel panel57;
		private System.Windows.Forms.Panel panel58;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Button butDicoFJ;
		private System.Windows.Forms.Button butMajCmbFJ;
		private System.Windows.Forms.TextBox txtCodeSiege;
		private System.Windows.Forms.CheckBox chkCedexSiege;
		private System.Windows.Forms.Button butRechercher;
		private System.Windows.Forms.TextBox txtCommentairesTigre;
		private System.Windows.Forms.TextBox txtCommentairesWeb;
		private System.Windows.Forms.DateTimePicker dtpOuverture;
		private System.Windows.Forms.DateTimePicker dtpFermeture;
		private System.Windows.Forms.TextBox txtTel24;
		private System.Windows.Forms.TextBox txtDtpOuverture;
		private System.Windows.Forms.TextBox txtDtpFermeture;
		private System.Windows.Forms.Button butModifier;
		private System.Windows.Forms.CheckBox chkPays;
		private System.Windows.Forms.Button butImprimer;
		private System.Windows.Forms.Button butCopieRemarques;
		private System.Windows.Forms.Button butID;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Button butResponsable;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.ComboBox cmbTypeIdentifiant;
		private System.Windows.Forms.TextBox txtTypeIdentifiant;
		private System.Windows.Forms.Button butGestionIdentifiant;
		private System.Windows.Forms.CheckBox chkVerifier;
		private System.Windows.Forms.CheckBox chkValider;
		private System.Windows.Forms.CheckBox chkClasser;
		private System.Windows.Forms.Button butEtablissement;
		private System.Windows.Forms.Button butHistorique;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Panel panSecteur;
		private System.Windows.Forms.Button butCommentairesTigreSecteur;
		private System.Windows.Forms.Button butSousTraitantSecteur;
		private System.Windows.Forms.TextBox txtOuvertureSecteur;
		private System.Windows.Forms.Label lblEtatSecteur;
		private System.Windows.Forms.TextBox txtEtatSecteur;
		private System.Windows.Forms.Button butDicoPersonne;
		private System.Windows.Forms.ComboBox cmbPRSecteur;
		private System.Windows.Forms.Button butResponsableSecteur;
		private System.Windows.Forms.TextBox txtNomSecteur;
		private System.Windows.Forms.Button butEtablissementSecteur;
		private System.Windows.Forms.Button butCommentairesWebSecteur;
		private System.Windows.Forms.TextBox txtCommentairesTigreSecteur;
		private System.Windows.Forms.Panel panCommentairesWebSecteur;
		private System.Windows.Forms.TextBox txtCommentairesWebSecteur;
		private System.Windows.Forms.Button butCopieRemarquesSecteur;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button butMajCmbPR;
		private TIGRE.ComboBoxEx cmbSecteur;
		private System.Windows.Forms.Panel panChoixSecteur;
		private System.Windows.Forms.Panel barreSecteur;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panTabCommentaireSecteur;
		private System.Windows.Forms.Button butMetier;
		private System.Windows.Forms.Panel panHistorique;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel28;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel29;
		private System.Windows.Forms.Panel panel30;
		private System.Windows.Forms.Panel panHistoriqueZoom;
		private System.Windows.Forms.Button butHistoriqueZoom;
		private System.Windows.Forms.TextBox txtHistoriqueZoom;
		private System.Windows.Forms.Label lblHistoriqueZoom;
		private System.Windows.Forms.DataGrid dagHistorique;
		private System.Windows.Forms.ComboBox cmbHistorique;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmbFiltre;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button butMessage;
		private System.ComponentModel.IContainer components = null;

		#endregion

		public FrmEntp(MDITigre fBase)
		{
			InitializeComponent();
			MdiParent = fBase;
			comportement = new CFormulaireTigre(fBase);
			comportement.ProcEnregistrement = "p_tigre_svEntreprise";
			comportement.ProcSuppression = "p_tigre_supprEntreprise";
			ListerChamps();
			RemplisTypes();
			RemplisListes();
			GetFont();
			fBase.CreerCible(this);
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntp));
            this.label8 = new System.Windows.Forms.Label();
            this.txtMel = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtSIREN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butFermer = new System.Windows.Forms.Button();
            this.butSupprimer = new System.Windows.Forms.Button();
            this.butSauver = new System.Windows.Forms.Button();
            this.butNouveau = new System.Windows.Forms.Button();
            this.cmbFJ = new System.Windows.Forms.ComboBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblEntp = new System.Windows.Forms.Label();
            this.lblSIREN = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butDicoFJ = new System.Windows.Forms.Button();
            this.lblFJ = new System.Windows.Forms.Label();
            this.txtAdr1Siege = new System.Windows.Forms.TextBox();
            this.txtAdr2Siege = new System.Windows.Forms.TextBox();
            this.lblAdr1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butCommunication = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblMetier = new System.Windows.Forms.Label();
            this.butAdresse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKbis = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panSecteur = new System.Windows.Forms.Panel();
            this.panCommentairesWebSecteur = new System.Windows.Forms.Panel();
            this.txtCommentairesWebSecteur = new System.Windows.Forms.TextBox();
            this.butCopieRemarquesSecteur = new System.Windows.Forms.Button();
            this.butCommentairesTigreSecteur = new System.Windows.Forms.Button();
            this.butSousTraitantSecteur = new System.Windows.Forms.Button();
            this.label77 = new System.Windows.Forms.Label();
            this.txtOuvertureSecteur = new System.Windows.Forms.TextBox();
            this.lblEtatSecteur = new System.Windows.Forms.Label();
            this.txtEtatSecteur = new System.Windows.Forms.TextBox();
            this.butDicoPersonne = new System.Windows.Forms.Button();
            this.cmbPRSecteur = new System.Windows.Forms.ComboBox();
            this.butResponsableSecteur = new System.Windows.Forms.Button();
            this.txtNomSecteur = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.butEtablissementSecteur = new System.Windows.Forms.Button();
            this.butMajCmbPR = new System.Windows.Forms.Button();
            this.butCommentairesWebSecteur = new System.Windows.Forms.Button();
            this.txtCommentairesTigreSecteur = new System.Windows.Forms.TextBox();
            this.barreSecteur = new System.Windows.Forms.Panel();
            this.panTabCommentaireSecteur = new System.Windows.Forms.Panel();
            this.panEL = new System.Windows.Forms.Panel();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.panel32 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.butSousTraitant = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel37 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.rbAdresseFrance = new System.Windows.Forms.RadioButton();
            this.rbAdresseEtranger = new System.Windows.Forms.RadioButton();
            this.panAdresse3 = new System.Windows.Forms.Panel();
            this.chkCedexSiege = new System.Windows.Forms.CheckBox();
            this.txtCPSiege = new System.Windows.Forms.TextBox();
            this.txtVilleSiege = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.panCedexSiege = new System.Windows.Forms.Panel();
            this.lblCedexSiege = new System.Windows.Forms.Label();
            this.butCompletion = new System.Windows.Forms.Button();
            this.txtCedexSiege = new System.Windows.Forms.TextBox();
            this.lblVille = new System.Windows.Forms.Label();
            this.butRechercher = new System.Windows.Forms.Button();
            this.butImprimer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ilsTypeEnt = new System.Windows.Forms.ImageList(this.components);
            this.txtCommentairesTigre = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.infobulle = new System.Windows.Forms.ToolTip(this.components);
            this.txtCommentairesWeb = new System.Windows.Forms.TextBox();
            this.butMajCmbFJ = new System.Windows.Forms.Button();
            this.butEtablissement = new System.Windows.Forms.Button();
            this.butModifier = new System.Windows.Forms.Button();
            this.butCopieRemarques = new System.Windows.Forms.Button();
            this.butID = new System.Windows.Forms.Button();
            this.butResponsable = new System.Windows.Forms.Button();
            this.butGestionIdentifiant = new System.Windows.Forms.Button();
            this.chkVerifier = new System.Windows.Forms.CheckBox();
            this.chkValider = new System.Windows.Forms.CheckBox();
            this.chkClasser = new System.Windows.Forms.CheckBox();
            this.butHistorique = new System.Windows.Forms.Button();
            this.butMetier = new System.Windows.Forms.Button();
            this.butMessage = new System.Windows.Forms.Button();
            this.cmbTypeEnt = new TIGRE.ComboBoxEx();
            this.cmbSecteur = new TIGRE.ComboBoxEx();
            this.label22 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.txtTel24 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.panel54 = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.dtpOuverture = new System.Windows.Forms.DateTimePicker();
            this.dtpFermeture = new System.Windows.Forms.DateTimePicker();
            this.txtCodeSiege = new System.Windows.Forms.TextBox();
            this.txtDtpOuverture = new System.Windows.Forms.TextBox();
            this.txtDtpFermeture = new System.Windows.Forms.TextBox();
            this.chkPays = new System.Windows.Forms.CheckBox();
            this.label80 = new System.Windows.Forms.Label();
            this.cmbTypeIdentifiant = new System.Windows.Forms.ComboBox();
            this.txtTypeIdentifiant = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.panChoixSecteur = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panHistorique = new System.Windows.Forms.Panel();
            this.panHistoriqueZoom = new System.Windows.Forms.Panel();
            this.butHistoriqueZoom = new System.Windows.Forms.Button();
            this.txtHistoriqueZoom = new System.Windows.Forms.TextBox();
            this.lblHistoriqueZoom = new System.Windows.Forms.Label();
            this.dagHistorique = new System.Windows.Forms.DataGrid();
            this.cmbHistorique = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFiltre = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panSecteur.SuspendLayout();
            this.panCommentairesWebSecteur.SuspendLayout();
            this.panEL.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panAdresse3.SuspendLayout();
            this.panCedexSiege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panChoixSecteur.SuspendLayout();
            this.panHistorique.SuspendLayout();
            this.panHistoriqueZoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dagHistorique)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(160, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 24);
            this.label8.TabIndex = 378;
            this.label8.Text = "Mail";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMel
            // 
            this.txtMel.BackColor = System.Drawing.Color.White;
            this.txtMel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMel.ForeColor = System.Drawing.Color.Black;
            this.txtMel.Location = new System.Drawing.Point(264, 304);
            this.txtMel.Name = "txtMel";
            this.txtMel.Size = new System.Drawing.Size(448, 20);
            this.txtMel.TabIndex = 12;
            this.txtMel.TextChanged += new System.EventHandler(this.ModifieCommunication);
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.ForeColor = System.Drawing.Color.Black;
            this.txtFax.Location = new System.Drawing.Point(624, 280);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(88, 20);
            this.txtFax.TabIndex = 11;
            this.txtFax.TextChanged += new System.EventHandler(this.ModifieCommunication);
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.ForeColor = System.Drawing.Color.Black;
            this.txtTel.Location = new System.Drawing.Point(264, 280);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(96, 20);
            this.txtTel.TabIndex = 9;
            this.txtTel.TextChanged += new System.EventHandler(this.ModifieCommunication);
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.txtNom.Location = new System.Drawing.Point(192, 56);
            this.txtNom.MaxLength = 350;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(712, 20);
            this.txtNom.TabIndex = 3;
            this.txtNom.TextChanged += new System.EventHandler(this.Modifie);
            // 
            // txtSIREN
            // 
            this.txtSIREN.BackColor = System.Drawing.Color.SkyBlue;
            this.txtSIREN.Location = new System.Drawing.Point(192, 32);
            this.txtSIREN.MaxLength = 15;
            this.txtSIREN.Name = "txtSIREN";
            this.txtSIREN.ReadOnly = true;
            this.txtSIREN.Size = new System.Drawing.Size(144, 20);
            this.txtSIREN.TabIndex = 1;
            this.txtSIREN.TextChanged += new System.EventHandler(this.ModifieID);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(160, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 377;
            this.label6.Text = "Téléphone";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butFermer
            // 
            this.butFermer.BackColor = System.Drawing.Color.White;
            this.butFermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butFermer.ForeColor = System.Drawing.Color.White;
            this.butFermer.Image = ((System.Drawing.Image)(resources.GetObject("butFermer.Image")));
            this.butFermer.Location = new System.Drawing.Point(952, 864);
            this.butFermer.Name = "butFermer";
            this.butFermer.Size = new System.Drawing.Size(32, 32);
            this.butFermer.TabIndex = 374;
            this.butFermer.TabStop = false;
            this.infobulle.SetToolTip(this.butFermer, "Fermer cet écran");
            this.butFermer.UseVisualStyleBackColor = false;
            this.butFermer.Click += new System.EventHandler(this.butFermer_Click);
            // 
            // butSupprimer
            // 
            this.butSupprimer.BackColor = System.Drawing.Color.White;
            this.butSupprimer.Enabled = false;
            this.butSupprimer.ForeColor = System.Drawing.Color.White;
            this.butSupprimer.Image = ((System.Drawing.Image)(resources.GetObject("butSupprimer.Image")));
            this.butSupprimer.Location = new System.Drawing.Point(8, 872);
            this.butSupprimer.Name = "butSupprimer";
            this.butSupprimer.Size = new System.Drawing.Size(24, 24);
            this.butSupprimer.TabIndex = 300;
            this.butSupprimer.TabStop = false;
            this.infobulle.SetToolTip(this.butSupprimer, "Supprimer");
            this.butSupprimer.UseVisualStyleBackColor = false;
            this.butSupprimer.Click += new System.EventHandler(this.butSupprimer_Click);
            // 
            // butSauver
            // 
            this.butSauver.BackColor = System.Drawing.Color.White;
            this.butSauver.ForeColor = System.Drawing.Color.White;
            this.butSauver.Image = ((System.Drawing.Image)(resources.GetObject("butSauver.Image")));
            this.butSauver.Location = new System.Drawing.Point(8, 88);
            this.butSauver.Name = "butSauver";
            this.butSauver.Size = new System.Drawing.Size(32, 32);
            this.butSauver.TabIndex = 299;
            this.butSauver.TabStop = false;
            this.infobulle.SetToolTip(this.butSauver, "Enregistrer");
            this.butSauver.UseVisualStyleBackColor = false;
            this.butSauver.Click += new System.EventHandler(this.butSauver_Click);
            // 
            // butNouveau
            // 
            this.butNouveau.BackColor = System.Drawing.Color.White;
            this.butNouveau.ForeColor = System.Drawing.Color.White;
            this.butNouveau.Image = ((System.Drawing.Image)(resources.GetObject("butNouveau.Image")));
            this.butNouveau.Location = new System.Drawing.Point(8, 8);
            this.butNouveau.Name = "butNouveau";
            this.butNouveau.Size = new System.Drawing.Size(32, 32);
            this.butNouveau.TabIndex = 4;
            this.butNouveau.TabStop = false;
            this.infobulle.SetToolTip(this.butNouveau, "Nouvelle entreprise");
            this.butNouveau.UseVisualStyleBackColor = false;
            this.butNouveau.Click += new System.EventHandler(this.butNouveau_Click);
            // 
            // cmbFJ
            // 
            this.cmbFJ.BackColor = System.Drawing.Color.White;
            this.cmbFJ.Location = new System.Drawing.Point(192, 80);
            this.cmbFJ.Name = "cmbFJ";
            this.cmbFJ.Size = new System.Drawing.Size(712, 21);
            this.cmbFJ.TabIndex = 4;
            this.cmbFJ.Tag = "0";
            this.cmbFJ.SelectedIndexChanged += new System.EventHandler(this.Modifie);
            // 
            // lblNom
            // 
            this.lblNom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblNom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNom.Location = new System.Drawing.Point(56, 56);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(136, 24);
            this.lblNom.TabIndex = 341;
            this.lblNom.Text = "Dénomination sociale";
            this.lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEntp
            // 
            this.lblEntp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.lblEntp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblEntp.Location = new System.Drawing.Point(56, 8);
            this.lblEntp.Name = "lblEntp";
            this.lblEntp.Size = new System.Drawing.Size(880, 16);
            this.lblEntp.TabIndex = 347;
            this.lblEntp.Text = "Données administratives";
            this.lblEntp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntp.BackColorChanged += new System.EventHandler(this.lblEntp_BackColorChanged);
            // 
            // lblSIREN
            // 
            this.lblSIREN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblSIREN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSIREN.ForeColor = System.Drawing.Color.White;
            this.lblSIREN.Location = new System.Drawing.Point(56, 32);
            this.lblSIREN.Name = "lblSIREN";
            this.lblSIREN.Size = new System.Drawing.Size(128, 24);
            this.lblSIREN.TabIndex = 346;
            this.lblSIREN.Text = "SIREN / Identifiant";
            this.lblSIREN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel1.Location = new System.Drawing.Point(48, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 904);
            this.panel1.TabIndex = 338;
            // 
            // butDicoFJ
            // 
            this.butDicoFJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butDicoFJ.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDicoFJ.ForeColor = System.Drawing.Color.White;
            this.butDicoFJ.Location = new System.Drawing.Point(912, 80);
            this.butDicoFJ.Name = "butDicoFJ";
            this.butDicoFJ.Size = new System.Drawing.Size(24, 21);
            this.butDicoFJ.TabIndex = 343;
            this.butDicoFJ.TabStop = false;
            this.butDicoFJ.Text = "...";
            this.butDicoFJ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.infobulle.SetToolTip(this.butDicoFJ, "Dictionnaire des formes juridiques");
            this.butDicoFJ.UseVisualStyleBackColor = false;
            this.butDicoFJ.Click += new System.EventHandler(this.butDicoFJ_Click);
            // 
            // lblFJ
            // 
            this.lblFJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblFJ.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFJ.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFJ.Location = new System.Drawing.Point(56, 80);
            this.lblFJ.Name = "lblFJ";
            this.lblFJ.Size = new System.Drawing.Size(104, 24);
            this.lblFJ.TabIndex = 348;
            this.lblFJ.Text = "Forme juridique";
            this.lblFJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAdr1Siege
            // 
            this.txtAdr1Siege.BackColor = System.Drawing.Color.White;
            this.txtAdr1Siege.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAdr1Siege.Location = new System.Drawing.Point(248, 416);
            this.txtAdr1Siege.MaxLength = 64;
            this.txtAdr1Siege.Name = "txtAdr1Siege";
            this.txtAdr1Siege.Size = new System.Drawing.Size(504, 20);
            this.txtAdr1Siege.TabIndex = 14;
            this.txtAdr1Siege.TextChanged += new System.EventHandler(this.ModifieAdresse);
            // 
            // txtAdr2Siege
            // 
            this.txtAdr2Siege.BackColor = System.Drawing.Color.White;
            this.txtAdr2Siege.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAdr2Siege.Location = new System.Drawing.Point(248, 440);
            this.txtAdr2Siege.Name = "txtAdr2Siege";
            this.txtAdr2Siege.Size = new System.Drawing.Size(504, 20);
            this.txtAdr2Siege.TabIndex = 15;
            this.txtAdr2Siege.TextChanged += new System.EventHandler(this.ModifieAdresse);
            // 
            // lblAdr1
            // 
            this.lblAdr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblAdr1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdr1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAdr1.Location = new System.Drawing.Point(168, 416);
            this.lblAdr1.Name = "lblAdr1";
            this.lblAdr1.Size = new System.Drawing.Size(64, 24);
            this.lblAdr1.TabIndex = 333;
            this.lblAdr1.Text = "N° et rue";
            this.lblAdr1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(584, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 24);
            this.label7.TabIndex = 375;
            this.label7.Text = "Fax";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butCommunication
            // 
            this.butCommunication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butCommunication.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCommunication.ForeColor = System.Drawing.Color.White;
            this.butCommunication.Location = new System.Drawing.Point(792, 280);
            this.butCommunication.Name = "butCommunication";
            this.butCommunication.Size = new System.Drawing.Size(136, 72);
            this.butCommunication.TabIndex = 343;
            this.butCommunication.TabStop = false;
            this.butCommunication.Text = "Autres moyens de communication";
            this.infobulle.SetToolTip(this.butCommunication, "Voir/modifier la liste des aututres moyens de communication de l\'entreprise");
            this.butCommunication.UseVisualStyleBackColor = false;
            this.butCommunication.Click += new System.EventHandler(this.butCommunication_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel6.Location = new System.Drawing.Point(944, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 904);
            this.panel6.TabIndex = 338;
            // 
            // lblMetier
            // 
            this.lblMetier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.lblMetier.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblMetier.Location = new System.Drawing.Point(56, 568);
            this.lblMetier.Name = "lblMetier";
            this.lblMetier.Size = new System.Drawing.Size(880, 16);
            this.lblMetier.TabIndex = 313;
            this.lblMetier.Text = "Données métier";
            this.lblMetier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butAdresse
            // 
            this.butAdresse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butAdresse.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdresse.ForeColor = System.Drawing.Color.White;
            this.butAdresse.Location = new System.Drawing.Point(792, 416);
            this.butAdresse.Name = "butAdresse";
            this.butAdresse.Size = new System.Drawing.Size(128, 72);
            this.butAdresse.TabIndex = 343;
            this.butAdresse.TabStop = false;
            this.butAdresse.Text = "Autres adresses";
            this.infobulle.SetToolTip(this.butAdresse, "Voir/modifier la liste des autres adresses de l\'entreprise");
            this.butAdresse.UseVisualStyleBackColor = false;
            this.butAdresse.Click += new System.EventHandler(this.butAdresse_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(704, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 346;
            this.label3.Text = "N° Kbis";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // txtKbis
            // 
            this.txtKbis.BackColor = System.Drawing.Color.White;
            this.txtKbis.Location = new System.Drawing.Point(760, 32);
            this.txtKbis.MaxLength = 11;
            this.txtKbis.Name = "txtKbis";
            this.txtKbis.Size = new System.Drawing.Size(8, 20);
            this.txtKbis.TabIndex = 2;
            this.txtKbis.Visible = false;
            this.txtKbis.TextChanged += new System.EventHandler(this.Modifie);
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.White;
            this.txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.ForeColor = System.Drawing.Color.Black;
            this.txtUrl.Location = new System.Drawing.Point(264, 328);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(448, 20);
            this.txtUrl.TabIndex = 13;
            this.txtUrl.TextChanged += new System.EventHandler(this.ModifieCommunication);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(160, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 24);
            this.label10.TabIndex = 378;
            this.label10.Text = "Adresse internet";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel4.Location = new System.Drawing.Point(64, 592);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(346, 2);
            this.panel4.TabIndex = 388;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel9.Location = new System.Drawing.Point(408, 592);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(2, 32);
            this.panel9.TabIndex = 388;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel11.Location = new System.Drawing.Point(64, 592);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(2, 32);
            this.panel11.TabIndex = 388;
            // 
            // panSecteur
            // 
            this.panSecteur.Controls.Add(this.panCommentairesWebSecteur);
            this.panSecteur.Controls.Add(this.butCommentairesTigreSecteur);
            this.panSecteur.Controls.Add(this.butSousTraitantSecteur);
            this.panSecteur.Controls.Add(this.label77);
            this.panSecteur.Controls.Add(this.txtOuvertureSecteur);
            this.panSecteur.Controls.Add(this.lblEtatSecteur);
            this.panSecteur.Controls.Add(this.txtEtatSecteur);
            this.panSecteur.Controls.Add(this.butDicoPersonne);
            this.panSecteur.Controls.Add(this.cmbPRSecteur);
            this.panSecteur.Controls.Add(this.butResponsableSecteur);
            this.panSecteur.Controls.Add(this.txtNomSecteur);
            this.panSecteur.Controls.Add(this.panel24);
            this.panSecteur.Controls.Add(this.panel25);
            this.panSecteur.Controls.Add(this.panel26);
            this.panSecteur.Controls.Add(this.label33);
            this.panSecteur.Controls.Add(this.panel27);
            this.panSecteur.Controls.Add(this.label25);
            this.panSecteur.Controls.Add(this.butEtablissementSecteur);
            this.panSecteur.Controls.Add(this.butMajCmbPR);
            this.panSecteur.Controls.Add(this.butCommentairesWebSecteur);
            this.panSecteur.Controls.Add(this.txtCommentairesTigreSecteur);
            this.panSecteur.Controls.Add(this.barreSecteur);
            this.panSecteur.Controls.Add(this.panTabCommentaireSecteur);
            this.panSecteur.ForeColor = System.Drawing.Color.White;
            this.panSecteur.Location = new System.Drawing.Point(64, 624);
            this.panSecteur.Name = "panSecteur";
            this.panSecteur.Size = new System.Drawing.Size(872, 248);
            this.panSecteur.TabIndex = 392;
            // 
            // panCommentairesWebSecteur
            // 
            this.panCommentairesWebSecteur.Controls.Add(this.txtCommentairesWebSecteur);
            this.panCommentairesWebSecteur.Controls.Add(this.butCopieRemarquesSecteur);
            this.panCommentairesWebSecteur.Location = new System.Drawing.Point(136, 128);
            this.panCommentairesWebSecteur.Name = "panCommentairesWebSecteur";
            this.panCommentairesWebSecteur.Size = new System.Drawing.Size(720, 104);
            this.panCommentairesWebSecteur.TabIndex = 818;
            // 
            // txtCommentairesWebSecteur
            // 
            this.txtCommentairesWebSecteur.BackColor = System.Drawing.Color.White;
            this.txtCommentairesWebSecteur.ForeColor = System.Drawing.Color.Black;
            this.txtCommentairesWebSecteur.Location = new System.Drawing.Point(8, 0);
            this.txtCommentairesWebSecteur.MaxLength = 650;
            this.txtCommentairesWebSecteur.Multiline = true;
            this.txtCommentairesWebSecteur.Name = "txtCommentairesWebSecteur";
            this.txtCommentairesWebSecteur.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommentairesWebSecteur.Size = new System.Drawing.Size(640, 104);
            this.txtCommentairesWebSecteur.TabIndex = 811;
            this.infobulle.SetToolTip(this.txtCommentairesWebSecteur, "Remarques visibles par l\'ensemble de l\'agence sur TigreWeb");
            this.txtCommentairesWebSecteur.Validated += new System.EventHandler(this.ModifieSecteur);
            // 
            // butCopieRemarquesSecteur
            // 
            this.butCopieRemarquesSecteur.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCopieRemarquesSecteur.Location = new System.Drawing.Point(656, 8);
            this.butCopieRemarquesSecteur.Name = "butCopieRemarquesSecteur";
            this.butCopieRemarquesSecteur.Size = new System.Drawing.Size(48, 23);
            this.butCopieRemarquesSecteur.TabIndex = 809;
            this.butCopieRemarquesSecteur.Text = "Copie";
            this.infobulle.SetToolTip(this.butCopieRemarquesSecteur, "Recopier les remarques pour Tigre");
            this.butCopieRemarquesSecteur.Click += new System.EventHandler(this.butCopieRemarquesSecteur_Click);
            // 
            // butCommentairesTigreSecteur
            // 
            this.butCommentairesTigreSecteur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCommentairesTigreSecteur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.butCommentairesTigreSecteur.Location = new System.Drawing.Point(48, 128);
            this.butCommentairesTigreSecteur.Name = "butCommentairesTigreSecteur";
            this.butCommentairesTigreSecteur.Size = new System.Drawing.Size(88, 32);
            this.butCommentairesTigreSecteur.TabIndex = 817;
            this.butCommentairesTigreSecteur.Text = "Remarques pour Tigre";
            this.infobulle.SetToolTip(this.butCommentairesTigreSecteur, "Remarques sur l\'activité visibles seulement sur Tigre");
            this.butCommentairesTigreSecteur.Click += new System.EventHandler(this.butCommentairesTigreSecteur_Click);
            // 
            // butSousTraitantSecteur
            // 
            this.butSousTraitantSecteur.ForeColor = System.Drawing.Color.White;
            this.butSousTraitantSecteur.Location = new System.Drawing.Point(592, 96);
            this.butSousTraitantSecteur.Name = "butSousTraitantSecteur";
            this.butSousTraitantSecteur.Size = new System.Drawing.Size(192, 24);
            this.butSousTraitantSecteur.TabIndex = 816;
            this.butSousTraitantSecteur.TabStop = false;
            this.butSousTraitantSecteur.Text = "Autres structures";
            this.infobulle.SetToolTip(this.butSousTraitantSecteur, "Autres structures liées à l\'activité de matières premières de l\'entreprise qui ne" +
        " sont pas enregistrées comme établissements");
            this.butSousTraitantSecteur.Click += new System.EventHandler(this.butSousTraitantSecteur_Click);
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label77.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.White;
            this.label77.Location = new System.Drawing.Point(8, 64);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(264, 24);
            this.label77.TabIndex = 815;
            this.label77.Text = "Date d\'ouverture du premier établissement";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOuvertureSecteur
            // 
            this.txtOuvertureSecteur.BackColor = System.Drawing.Color.SkyBlue;
            this.txtOuvertureSecteur.ForeColor = System.Drawing.Color.Black;
            this.txtOuvertureSecteur.Location = new System.Drawing.Point(272, 64);
            this.txtOuvertureSecteur.Name = "txtOuvertureSecteur";
            this.txtOuvertureSecteur.ReadOnly = true;
            this.txtOuvertureSecteur.Size = new System.Drawing.Size(72, 20);
            this.txtOuvertureSecteur.TabIndex = 814;
            this.txtOuvertureSecteur.TabStop = false;
            this.txtOuvertureSecteur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEtatSecteur
            // 
            this.lblEtatSecteur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblEtatSecteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtatSecteur.ForeColor = System.Drawing.Color.White;
            this.lblEtatSecteur.Location = new System.Drawing.Point(754, 8);
            this.lblEtatSecteur.Name = "lblEtatSecteur";
            this.lblEtatSecteur.Size = new System.Drawing.Size(104, 32);
            this.lblEtatSecteur.TabIndex = 812;
            this.lblEtatSecteur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEtatSecteur
            // 
            this.txtEtatSecteur.BackColor = System.Drawing.Color.White;
            this.txtEtatSecteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEtatSecteur.Location = new System.Drawing.Point(848, 40);
            this.txtEtatSecteur.MaxLength = 64;
            this.txtEtatSecteur.Name = "txtEtatSecteur";
            this.txtEtatSecteur.Size = new System.Drawing.Size(8, 20);
            this.txtEtatSecteur.TabIndex = 813;
            this.txtEtatSecteur.TabStop = false;
            this.txtEtatSecteur.Visible = false;
            this.txtEtatSecteur.TextChanged += new System.EventHandler(this.txtEtatSecteur_TextChanged);
            // 
            // butDicoPersonne
            // 
            this.butDicoPersonne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDicoPersonne.Location = new System.Drawing.Point(608, 32);
            this.butDicoPersonne.Name = "butDicoPersonne";
            this.butDicoPersonne.Size = new System.Drawing.Size(24, 22);
            this.butDicoPersonne.TabIndex = 391;
            this.butDicoPersonne.Text = "...";
            this.butDicoPersonne.Click += new System.EventHandler(this.butDicoPersonne_Click);
            // 
            // cmbPRSecteur
            // 
            this.cmbPRSecteur.Location = new System.Drawing.Point(208, 32);
            this.cmbPRSecteur.Name = "cmbPRSecteur";
            this.cmbPRSecteur.Size = new System.Drawing.Size(392, 21);
            this.cmbPRSecteur.TabIndex = 390;
            this.cmbPRSecteur.DropDown += new System.EventHandler(this.ModifiePRSecteur);
            this.cmbPRSecteur.SelectedIndexChanged += new System.EventHandler(this.ModifieSecteur);
            this.cmbPRSecteur.Enter += new System.EventHandler(this.ModifiePRSecteur);
            // 
            // butResponsableSecteur
            // 
            this.butResponsableSecteur.ForeColor = System.Drawing.Color.White;
            this.butResponsableSecteur.Location = new System.Drawing.Point(144, 96);
            this.butResponsableSecteur.Name = "butResponsableSecteur";
            this.butResponsableSecteur.Size = new System.Drawing.Size(192, 24);
            this.butResponsableSecteur.TabIndex = 389;
            this.butResponsableSecteur.Text = "Autres personnes responsables";
            this.infobulle.SetToolTip(this.butResponsableSecteur, "Responsables de l\'entreprise");
            this.butResponsableSecteur.Click += new System.EventHandler(this.butResponsable_Click);
            // 
            // txtNomSecteur
            // 
            this.txtNomSecteur.BackColor = System.Drawing.Color.White;
            this.txtNomSecteur.ForeColor = System.Drawing.Color.Black;
            this.txtNomSecteur.Location = new System.Drawing.Point(208, 8);
            this.txtNomSecteur.MaxLength = 255;
            this.txtNomSecteur.Name = "txtNomSecteur";
            this.txtNomSecteur.Size = new System.Drawing.Size(496, 20);
            this.txtNomSecteur.TabIndex = 377;
            this.txtNomSecteur.TextChanged += new System.EventHandler(this.ModifieSecteur);
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(2, 240);
            this.panel24.TabIndex = 338;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel25.Location = new System.Drawing.Point(864, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(2, 240);
            this.panel25.TabIndex = 338;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel26.Location = new System.Drawing.Point(696, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(168, 2);
            this.panel26.TabIndex = 338;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label33.Location = new System.Drawing.Point(8, 8);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(200, 24);
            this.label33.TabIndex = 367;
            this.label33.Text = "Nom commercial/interne/abrégé";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            this.panel27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel27.Location = new System.Drawing.Point(0, 240);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(864, 2);
            this.panel27.TabIndex = 338;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(8, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(192, 24);
            this.label25.TabIndex = 367;
            this.label25.Text = "Responsable de l\'activité";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butEtablissementSecteur
            // 
            this.butEtablissementSecteur.ForeColor = System.Drawing.Color.White;
            this.butEtablissementSecteur.Location = new System.Drawing.Point(368, 96);
            this.butEtablissementSecteur.Name = "butEtablissementSecteur";
            this.butEtablissementSecteur.Size = new System.Drawing.Size(192, 24);
            this.butEtablissementSecteur.TabIndex = 389;
            this.butEtablissementSecteur.Text = "Etablissements";
            this.infobulle.SetToolTip(this.butEtablissementSecteur, "Etablissements de l\'entreprise ayant une activité de matières premières");
            this.butEtablissementSecteur.Click += new System.EventHandler(this.butEtablissementSecteur_Click);
            // 
            // butMajCmbPR
            // 
            this.butMajCmbPR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMajCmbPR.ForeColor = System.Drawing.Color.White;
            this.butMajCmbPR.Location = new System.Drawing.Point(640, 800);
            this.butMajCmbPR.Name = "butMajCmbPR";
            this.butMajCmbPR.Size = new System.Drawing.Size(8, 8);
            this.butMajCmbPR.TabIndex = 380;
            this.butMajCmbPR.Text = "...";
            this.infobulle.SetToolTip(this.butMajCmbPR, "Liste des personnes");
            this.butMajCmbPR.Click += new System.EventHandler(this.MajCmbPR);
            // 
            // butCommentairesWebSecteur
            // 
            this.butCommentairesWebSecteur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butCommentairesWebSecteur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.butCommentairesWebSecteur.Location = new System.Drawing.Point(48, 160);
            this.butCommentairesWebSecteur.Name = "butCommentairesWebSecteur";
            this.butCommentairesWebSecteur.Size = new System.Drawing.Size(88, 32);
            this.butCommentairesWebSecteur.TabIndex = 817;
            this.butCommentairesWebSecteur.Text = "Remarques pour TigreWeb";
            this.infobulle.SetToolTip(this.butCommentairesWebSecteur, "Remarques sur l\'activité visibles sur TigreWeb");
            this.butCommentairesWebSecteur.Click += new System.EventHandler(this.butCommentairesWebSecteur_Click);
            // 
            // txtCommentairesTigreSecteur
            // 
            this.txtCommentairesTigreSecteur.BackColor = System.Drawing.Color.White;
            this.txtCommentairesTigreSecteur.ForeColor = System.Drawing.Color.Black;
            this.txtCommentairesTigreSecteur.Location = new System.Drawing.Point(144, 128);
            this.txtCommentairesTigreSecteur.MaxLength = 650;
            this.txtCommentairesTigreSecteur.Multiline = true;
            this.txtCommentairesTigreSecteur.Name = "txtCommentairesTigreSecteur";
            this.txtCommentairesTigreSecteur.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommentairesTigreSecteur.Size = new System.Drawing.Size(640, 104);
            this.txtCommentairesTigreSecteur.TabIndex = 810;
            this.infobulle.SetToolTip(this.txtCommentairesTigreSecteur, "Remarques visibles par les seuls utilisateurs de Tigre");
            this.txtCommentairesTigreSecteur.Validated += new System.EventHandler(this.ModifieSecteur);
            // 
            // barreSecteur
            // 
            this.barreSecteur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.barreSecteur.Location = new System.Drawing.Point(344, 0);
            this.barreSecteur.Name = "barreSecteur";
            this.barreSecteur.Size = new System.Drawing.Size(354, 2);
            this.barreSecteur.TabIndex = 338;
            // 
            // panTabCommentaireSecteur
            // 
            this.panTabCommentaireSecteur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panTabCommentaireSecteur.Location = new System.Drawing.Point(40, 128);
            this.panTabCommentaireSecteur.Name = "panTabCommentaireSecteur";
            this.panTabCommentaireSecteur.Size = new System.Drawing.Size(8, 8);
            this.panTabCommentaireSecteur.TabIndex = 338;
            // 
            // panEL
            // 
            this.panEL.Controls.Add(this.textBox32);
            this.panEL.Controls.Add(this.label41);
            this.panEL.Controls.Add(this.label43);
            this.panEL.Controls.Add(this.textBox35);
            this.panEL.Controls.Add(this.label44);
            this.panEL.Controls.Add(this.textBox36);
            this.panEL.Controls.Add(this.panel32);
            this.panEL.Controls.Add(this.panel33);
            this.panEL.Controls.Add(this.panel34);
            this.panEL.Controls.Add(this.panel35);
            this.panEL.Location = new System.Drawing.Point(56, -800);
            this.panEL.Name = "panEL";
            this.panEL.Size = new System.Drawing.Size(584, 317);
            this.panEL.TabIndex = 394;
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.Color.White;
            this.textBox32.ForeColor = System.Drawing.Color.White;
            this.textBox32.Location = new System.Drawing.Point(136, 8);
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(400, 20);
            this.textBox32.TabIndex = 385;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label41.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label41.Location = new System.Drawing.Point(8, 8);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(136, 24);
            this.label41.TabIndex = 383;
            this.label41.Text = "Nom interne/abrégé";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label43.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label43.Location = new System.Drawing.Point(8, 40);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(96, 48);
            this.label43.TabIndex = 382;
            this.label43.Text = "Commentaires (non diffusés sur TigreWeb)";
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.Color.White;
            this.textBox35.ForeColor = System.Drawing.Color.White;
            this.textBox35.Location = new System.Drawing.Point(112, 40);
            this.textBox35.MaxLength = 255;
            this.textBox35.Multiline = true;
            this.textBox35.Name = "textBox35";
            this.textBox35.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox35.Size = new System.Drawing.Size(464, 48);
            this.textBox35.TabIndex = 381;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label44.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label44.Location = new System.Drawing.Point(8, 96);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(88, 48);
            this.label44.TabIndex = 379;
            this.label44.Text = "Observations (diffusées sur TigreWeb)";
            // 
            // textBox36
            // 
            this.textBox36.BackColor = System.Drawing.Color.White;
            this.textBox36.ForeColor = System.Drawing.Color.White;
            this.textBox36.Location = new System.Drawing.Point(112, 96);
            this.textBox36.MaxLength = 255;
            this.textBox36.Multiline = true;
            this.textBox36.Name = "textBox36";
            this.textBox36.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox36.Size = new System.Drawing.Size(464, 48);
            this.textBox36.TabIndex = 380;
            // 
            // panel32
            // 
            this.panel32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel32.Location = new System.Drawing.Point(0, 0);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(2, 152);
            this.panel32.TabIndex = 338;
            // 
            // panel33
            // 
            this.panel33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel33.Location = new System.Drawing.Point(582, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(2, 152);
            this.panel33.TabIndex = 338;
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel34.Location = new System.Drawing.Point(288, 0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(296, 2);
            this.panel34.TabIndex = 338;
            // 
            // panel35
            // 
            this.panel35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel35.Location = new System.Drawing.Point(0, 152);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(584, 2);
            this.panel35.TabIndex = 338;
            // 
            // butSousTraitant
            // 
            this.butSousTraitant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butSousTraitant.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSousTraitant.ForeColor = System.Drawing.Color.White;
            this.butSousTraitant.Location = new System.Drawing.Point(672, 528);
            this.butSousTraitant.Name = "butSousTraitant";
            this.butSousTraitant.Size = new System.Drawing.Size(224, 24);
            this.butSousTraitant.TabIndex = 343;
            this.butSousTraitant.TabStop = false;
            this.butSousTraitant.Text = "Sous-traitants de l\'entreprise";
            this.infobulle.SetToolTip(this.butSousTraitant, "Autres structures liées aux activités de l\'entreprise et qui ne sont pas enregist" +
        "rées comme établissements");
            this.butSousTraitant.UseVisualStyleBackColor = false;
            this.butSousTraitant.Click += new System.EventHandler(this.butSousTraitant_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.textBox33);
            this.panel8.Controls.Add(this.panel36);
            this.panel8.Controls.Add(this.panel37);
            this.panel8.Controls.Add(this.panel38);
            this.panel8.Controls.Add(this.label40);
            this.panel8.Controls.Add(this.panel39);
            this.panel8.Controls.Add(this.textBox34);
            this.panel8.Controls.Add(this.label42);
            this.panel8.Controls.Add(this.label45);
            this.panel8.Controls.Add(this.textBox37);
            this.panel8.Location = new System.Drawing.Point(-160, -704);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(672, 478);
            this.panel8.TabIndex = 392;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(112, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 24);
            this.button2.TabIndex = 389;
            this.button2.Text = "Activités matières premières";
            // 
            // textBox33
            // 
            this.textBox33.BackColor = System.Drawing.Color.White;
            this.textBox33.ForeColor = System.Drawing.Color.White;
            this.textBox33.Location = new System.Drawing.Point(136, 8);
            this.textBox33.Name = "textBox33";
            this.textBox33.ReadOnly = true;
            this.textBox33.Size = new System.Drawing.Size(400, 20);
            this.textBox33.TabIndex = 377;
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel36.Location = new System.Drawing.Point(0, 0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(2, 288);
            this.panel36.TabIndex = 338;
            // 
            // panel37
            // 
            this.panel37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel37.Location = new System.Drawing.Point(582, 0);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(2, 288);
            this.panel37.TabIndex = 338;
            // 
            // panel38
            // 
            this.panel38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel38.Location = new System.Drawing.Point(288, 0);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(296, 2);
            this.panel38.TabIndex = 338;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label40.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label40.Location = new System.Drawing.Point(8, 8);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(136, 24);
            this.label40.TabIndex = 367;
            this.label40.Text = "Nom interne/abrégé";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel39.Location = new System.Drawing.Point(0, 286);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(584, 2);
            this.panel39.TabIndex = 338;
            // 
            // textBox34
            // 
            this.textBox34.BackColor = System.Drawing.Color.White;
            this.textBox34.ForeColor = System.Drawing.Color.White;
            this.textBox34.Location = new System.Drawing.Point(112, 128);
            this.textBox34.MaxLength = 255;
            this.textBox34.Multiline = true;
            this.textBox34.Name = "textBox34";
            this.textBox34.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox34.Size = new System.Drawing.Size(464, 48);
            this.textBox34.TabIndex = 354;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label42.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label42.Location = new System.Drawing.Point(8, 120);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(88, 48);
            this.label42.TabIndex = 353;
            this.label42.Text = "Observations (diffusées sur TigreWeb)";
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label45.Location = new System.Drawing.Point(8, 72);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(96, 48);
            this.label45.TabIndex = 356;
            this.label45.Text = "Commentaires (non diffusés sur TigreWeb)";
            // 
            // textBox37
            // 
            this.textBox37.BackColor = System.Drawing.Color.White;
            this.textBox37.ForeColor = System.Drawing.Color.White;
            this.textBox37.Location = new System.Drawing.Point(112, 72);
            this.textBox37.MaxLength = 255;
            this.textBox37.Multiline = true;
            this.textBox37.Name = "textBox37";
            this.textBox37.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox37.Size = new System.Drawing.Size(464, 52);
            this.textBox37.TabIndex = 355;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(64, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 16);
            this.label1.TabIndex = 313;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.rbAdresseFrance);
            this.panel40.Controls.Add(this.rbAdresseEtranger);
            this.panel40.ForeColor = System.Drawing.Color.White;
            this.panel40.Location = new System.Drawing.Point(168, 392);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(304, 16);
            this.panel40.TabIndex = 395;
            // 
            // rbAdresseFrance
            // 
            this.rbAdresseFrance.Checked = true;
            this.rbAdresseFrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAdresseFrance.Location = new System.Drawing.Point(0, 0);
            this.rbAdresseFrance.Name = "rbAdresseFrance";
            this.rbAdresseFrance.Size = new System.Drawing.Size(120, 16);
            this.rbAdresseFrance.TabIndex = 0;
            this.rbAdresseFrance.TabStop = true;
            this.rbAdresseFrance.Text = "en France";
            this.rbAdresseFrance.Click += new System.EventHandler(this.rbAdresseFrance_Click);
            // 
            // rbAdresseEtranger
            // 
            this.rbAdresseEtranger.Location = new System.Drawing.Point(168, 0);
            this.rbAdresseEtranger.Name = "rbAdresseEtranger";
            this.rbAdresseEtranger.Size = new System.Drawing.Size(120, 16);
            this.rbAdresseEtranger.TabIndex = 0;
            this.rbAdresseEtranger.Text = "à l\'étranger";
            this.rbAdresseEtranger.Click += new System.EventHandler(this.rbAdresseEtranger_Click);
            // 
            // panAdresse3
            // 
            this.panAdresse3.Controls.Add(this.chkCedexSiege);
            this.panAdresse3.Controls.Add(this.txtCPSiege);
            this.panAdresse3.Controls.Add(this.txtVilleSiege);
            this.panAdresse3.Controls.Add(this.lblCP);
            this.panAdresse3.Controls.Add(this.panCedexSiege);
            this.panAdresse3.Controls.Add(this.lblVille);
            this.panAdresse3.ForeColor = System.Drawing.Color.White;
            this.panAdresse3.Location = new System.Drawing.Point(168, 464);
            this.panAdresse3.Name = "panAdresse3";
            this.panAdresse3.Size = new System.Drawing.Size(608, 24);
            this.panAdresse3.TabIndex = 16;
            this.panAdresse3.TabStop = true;
            // 
            // chkCedexSiege
            // 
            this.chkCedexSiege.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCedexSiege.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCedexSiege.Location = new System.Drawing.Point(504, 0);
            this.chkCedexSiege.Name = "chkCedexSiege";
            this.chkCedexSiege.Size = new System.Drawing.Size(96, 24);
            this.chkCedexSiege.TabIndex = 18;
            this.chkCedexSiege.Text = "CEDEX";
            this.chkCedexSiege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCedexSiege.CheckedChanged += new System.EventHandler(this.chkCedexSiege_CheckedChanged);
            // 
            // txtCPSiege
            // 
            this.txtCPSiege.BackColor = System.Drawing.Color.White;
            this.txtCPSiege.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCPSiege.Location = new System.Drawing.Point(80, 0);
            this.txtCPSiege.MaxLength = 20;
            this.txtCPSiege.Name = "txtCPSiege";
            this.txtCPSiege.Size = new System.Drawing.Size(72, 20);
            this.txtCPSiege.TabIndex = 17;
            this.txtCPSiege.Enter += new System.EventHandler(this.txtCPSiege_Enter);
            // 
            // txtVilleSiege
            // 
            this.txtVilleSiege.BackColor = System.Drawing.Color.SkyBlue;
            this.txtVilleSiege.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtVilleSiege.Location = new System.Drawing.Point(197, 0);
            this.txtVilleSiege.Name = "txtVilleSiege";
            this.txtVilleSiege.ReadOnly = true;
            this.txtVilleSiege.Size = new System.Drawing.Size(277, 20);
            this.txtVilleSiege.TabIndex = 386;
            this.txtVilleSiege.TabStop = false;
            // 
            // lblCP
            // 
            this.lblCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblCP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCP.Location = new System.Drawing.Point(0, 0);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(80, 24);
            this.lblCP.TabIndex = 387;
            this.lblCP.Text = "Code postal";
            this.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panCedexSiege
            // 
            this.panCedexSiege.Controls.Add(this.lblCedexSiege);
            this.panCedexSiege.Controls.Add(this.butCompletion);
            this.panCedexSiege.Controls.Add(this.txtCedexSiege);
            this.panCedexSiege.Location = new System.Drawing.Point(480, 0);
            this.panCedexSiege.Name = "panCedexSiege";
            this.panCedexSiege.Size = new System.Drawing.Size(104, 24);
            this.panCedexSiege.TabIndex = 389;
            // 
            // lblCedexSiege
            // 
            this.lblCedexSiege.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblCedexSiege.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedexSiege.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCedexSiege.Location = new System.Drawing.Point(24, 0);
            this.lblCedexSiege.Name = "lblCedexSiege";
            this.lblCedexSiege.Size = new System.Drawing.Size(56, 21);
            this.lblCedexSiege.TabIndex = 343;
            this.lblCedexSiege.Tag = "v";
            this.lblCedexSiege.Text = "CEDEX";
            this.lblCedexSiege.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butCompletion
            // 
            this.butCompletion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butCompletion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCompletion.ForeColor = System.Drawing.Color.White;
            this.butCompletion.Location = new System.Drawing.Point(0, 0);
            this.butCompletion.Name = "butCompletion";
            this.butCompletion.Size = new System.Drawing.Size(20, 21);
            this.butCompletion.TabIndex = 18;
            this.butCompletion.Text = "?";
            this.infobulle.SetToolTip(this.butCompletion, "Dictionnaire des villes");
            this.butCompletion.UseVisualStyleBackColor = false;
            this.butCompletion.Click += new System.EventHandler(this.butCompletion_Click);
            // 
            // txtCedexSiege
            // 
            this.txtCedexSiege.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCedexSiege.Location = new System.Drawing.Point(80, 0);
            this.txtCedexSiege.Name = "txtCedexSiege";
            this.txtCedexSiege.Size = new System.Drawing.Size(26, 20);
            this.txtCedexSiege.TabIndex = 18;
            this.txtCedexSiege.TabStop = false;
            this.txtCedexSiege.TextChanged += new System.EventHandler(this.txtCedexSiege_TextChanged);
            // 
            // lblVille
            // 
            this.lblVille.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.lblVille.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVille.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVille.Location = new System.Drawing.Point(165, 0);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(35, 24);
            this.lblVille.TabIndex = 388;
            this.lblVille.Text = "Ville";
            this.lblVille.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butRechercher
            // 
            this.butRechercher.BackColor = System.Drawing.Color.White;
            this.butRechercher.ForeColor = System.Drawing.Color.White;
            this.butRechercher.Image = ((System.Drawing.Image)(resources.GetObject("butRechercher.Image")));
            this.butRechercher.Location = new System.Drawing.Point(952, 8);
            this.butRechercher.Name = "butRechercher";
            this.butRechercher.Size = new System.Drawing.Size(32, 32);
            this.butRechercher.TabIndex = 299;
            this.butRechercher.TabStop = false;
            this.infobulle.SetToolTip(this.butRechercher, "Rechercher une entreprise");
            this.butRechercher.UseVisualStyleBackColor = false;
            this.butRechercher.Click += new System.EventHandler(this.butRechercher_Click);
            // 
            // butImprimer
            // 
            this.butImprimer.BackColor = System.Drawing.Color.White;
            this.butImprimer.ForeColor = System.Drawing.Color.White;
            this.butImprimer.Image = ((System.Drawing.Image)(resources.GetObject("butImprimer.Image")));
            this.butImprimer.Location = new System.Drawing.Point(952, 48);
            this.butImprimer.Name = "butImprimer";
            this.butImprimer.Size = new System.Drawing.Size(32, 32);
            this.butImprimer.TabIndex = 300;
            this.butImprimer.TabStop = false;
            this.infobulle.SetToolTip(this.butImprimer, "Imprimer la fiche");
            this.butImprimer.UseVisualStyleBackColor = false;
            this.butImprimer.Click += new System.EventHandler(this.butImprimer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(280, 632);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 72);
            this.pictureBox1.TabIndex = 397;
            this.pictureBox1.TabStop = false;
            // 
            // ilsTypeEnt
            // 
            this.ilsTypeEnt.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsTypeEnt.ImageStream")));
            this.ilsTypeEnt.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsTypeEnt.Images.SetKeyName(0, "");
            this.ilsTypeEnt.Images.SetKeyName(1, "");
            // 
            // txtCommentairesTigre
            // 
            this.txtCommentairesTigre.BackColor = System.Drawing.Color.White;
            this.txtCommentairesTigre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommentairesTigre.ForeColor = System.Drawing.Color.Black;
            this.txtCommentairesTigre.Location = new System.Drawing.Point(192, 136);
            this.txtCommentairesTigre.MaxLength = 600;
            this.txtCommentairesTigre.Multiline = true;
            this.txtCommentairesTigre.Name = "txtCommentairesTigre";
            this.txtCommentairesTigre.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommentairesTigre.Size = new System.Drawing.Size(712, 48);
            this.txtCommentairesTigre.TabIndex = 7;
            this.infobulle.SetToolTip(this.txtCommentairesTigre, "Remarques sur l\'entreprisevisibles par les seuls utilisateurs de Tigre");
            this.txtCommentairesTigre.TextChanged += new System.EventHandler(this.Modifie);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label36.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label36.Location = new System.Drawing.Point(56, 144);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(104, 16);
            this.label36.TabIndex = 378;
            this.label36.Text = "Remarques";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel3.Location = new System.Drawing.Point(64, 624);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 2);
            this.panel3.TabIndex = 388;
            // 
            // txtCommentairesWeb
            // 
            this.txtCommentairesWeb.BackColor = System.Drawing.Color.White;
            this.txtCommentairesWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommentairesWeb.ForeColor = System.Drawing.Color.Black;
            this.txtCommentairesWeb.Location = new System.Drawing.Point(192, 192);
            this.txtCommentairesWeb.MaxLength = 600;
            this.txtCommentairesWeb.Multiline = true;
            this.txtCommentairesWeb.Name = "txtCommentairesWeb";
            this.txtCommentairesWeb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommentairesWeb.Size = new System.Drawing.Size(712, 48);
            this.txtCommentairesWeb.TabIndex = 8;
            this.infobulle.SetToolTip(this.txtCommentairesWeb, "Remarques sur l\'entreprise visibles par l\'ensemble de l\'agence sur TigreWeb");
            this.txtCommentairesWeb.TextChanged += new System.EventHandler(this.Modifie);
            // 
            // butMajCmbFJ
            // 
            this.butMajCmbFJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butMajCmbFJ.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMajCmbFJ.ForeColor = System.Drawing.Color.White;
            this.butMajCmbFJ.Location = new System.Drawing.Point(912, -120);
            this.butMajCmbFJ.Name = "butMajCmbFJ";
            this.butMajCmbFJ.Size = new System.Drawing.Size(24, 120);
            this.butMajCmbFJ.TabIndex = 343;
            this.butMajCmbFJ.TabStop = false;
            this.butMajCmbFJ.Text = "...";
            this.butMajCmbFJ.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.infobulle.SetToolTip(this.butMajCmbFJ, "Dictionnaire des formes juridiques");
            this.butMajCmbFJ.UseVisualStyleBackColor = false;
            this.butMajCmbFJ.Click += new System.EventHandler(this.MajCmbFJ);
            // 
            // butEtablissement
            // 
            this.butEtablissement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butEtablissement.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butEtablissement.ForeColor = System.Drawing.Color.White;
            this.butEtablissement.Location = new System.Drawing.Point(416, 528);
            this.butEtablissement.Name = "butEtablissement";
            this.butEtablissement.Size = new System.Drawing.Size(224, 24);
            this.butEtablissement.TabIndex = 343;
            this.butEtablissement.TabStop = false;
            this.butEtablissement.Text = "Etablissements de l\'entreprise";
            this.infobulle.SetToolTip(this.butEtablissement, "Etablissements de l\'entreprise");
            this.butEtablissement.UseVisualStyleBackColor = false;
            this.butEtablissement.Click += new System.EventHandler(this.butEtablissement_Click);
            // 
            // butModifier
            // 
            this.butModifier.BackColor = System.Drawing.Color.White;
            this.butModifier.ForeColor = System.Drawing.Color.White;
            this.butModifier.Image = ((System.Drawing.Image)(resources.GetObject("butModifier.Image")));
            this.butModifier.Location = new System.Drawing.Point(8, 48);
            this.butModifier.Name = "butModifier";
            this.butModifier.Size = new System.Drawing.Size(32, 32);
            this.butModifier.TabIndex = 4;
            this.butModifier.TabStop = false;
            this.infobulle.SetToolTip(this.butModifier, "Modifier les données administratives");
            this.butModifier.UseVisualStyleBackColor = false;
            this.butModifier.Click += new System.EventHandler(this.butModifier_Click);
            // 
            // butCopieRemarques
            // 
            this.butCopieRemarques.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCopieRemarques.Location = new System.Drawing.Point(144, 216);
            this.butCopieRemarques.Name = "butCopieRemarques";
            this.butCopieRemarques.Size = new System.Drawing.Size(48, 23);
            this.butCopieRemarques.TabIndex = 433;
            this.butCopieRemarques.Text = "Copie";
            this.infobulle.SetToolTip(this.butCopieRemarques, "Recopier les remarques pour Tigre");
            this.butCopieRemarques.Click += new System.EventHandler(this.butCopieRemarques_Click);
            // 
            // butID
            // 
            this.butID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butID.Location = new System.Drawing.Point(776, 32);
            this.butID.Name = "butID";
            this.butID.Size = new System.Drawing.Size(20, 20);
            this.butID.TabIndex = 434;
            this.butID.Text = "---";
            this.infobulle.SetToolTip(this.butID, "Changer l\'identifiant");
            this.butID.Visible = false;
            this.butID.Click += new System.EventHandler(this.butID_Click);
            // 
            // butResponsable
            // 
            this.butResponsable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.butResponsable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butResponsable.ForeColor = System.Drawing.Color.White;
            this.butResponsable.Location = new System.Drawing.Point(152, 528);
            this.butResponsable.Name = "butResponsable";
            this.butResponsable.Size = new System.Drawing.Size(224, 24);
            this.butResponsable.TabIndex = 343;
            this.butResponsable.TabStop = false;
            this.butResponsable.Text = "Responsables de l\'entreprise";
            this.infobulle.SetToolTip(this.butResponsable, "Responsables de l\'entreprise");
            this.butResponsable.UseVisualStyleBackColor = false;
            this.butResponsable.Click += new System.EventHandler(this.butResponsable_Click);
            // 
            // butGestionIdentifiant
            // 
            this.butGestionIdentifiant.Location = new System.Drawing.Point(800, 32);
            this.butGestionIdentifiant.Name = "butGestionIdentifiant";
            this.butGestionIdentifiant.Size = new System.Drawing.Size(104, 22);
            this.butGestionIdentifiant.TabIndex = 436;
            this.butGestionIdentifiant.Text = "Gérer l\'identifiant";
            this.infobulle.SetToolTip(this.butGestionIdentifiant, "Date d\'échéance / prolongation / changer le type du code");
            this.butGestionIdentifiant.Visible = false;
            this.butGestionIdentifiant.Click += new System.EventHandler(this.butGestionIdentifiant_Click);
            // 
            // chkVerifier
            // 
            this.chkVerifier.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkVerifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerifier.Location = new System.Drawing.Point(944, 128);
            this.chkVerifier.Name = "chkVerifier";
            this.chkVerifier.Size = new System.Drawing.Size(48, 32);
            this.chkVerifier.TabIndex = 440;
            this.chkVerifier.Text = "A vérifier";
            this.chkVerifier.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.infobulle.SetToolTip(this.chkVerifier, "Cocher pour demander une vérification et envoyer un message");
            this.chkVerifier.Click += new System.EventHandler(this.chkVerifier_Click);
            // 
            // chkValider
            // 
            this.chkValider.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkValider.Location = new System.Drawing.Point(944, 168);
            this.chkValider.Name = "chkValider";
            this.chkValider.Size = new System.Drawing.Size(48, 32);
            this.chkValider.TabIndex = 439;
            this.chkValider.Text = "A valider";
            this.chkValider.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.infobulle.SetToolTip(this.chkValider, "Cocher pour demander une validation et envoyer un message");
            this.chkValider.Click += new System.EventHandler(this.chkValider_Click);
            // 
            // chkClasser
            // 
            this.chkClasser.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkClasser.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClasser.Location = new System.Drawing.Point(944, 208);
            this.chkClasser.Name = "chkClasser";
            this.chkClasser.Size = new System.Drawing.Size(48, 32);
            this.chkClasser.TabIndex = 438;
            this.chkClasser.Text = "A classer";
            this.chkClasser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.infobulle.SetToolTip(this.chkClasser, "Cocher pour classer et archiver la demande");
            this.chkClasser.Click += new System.EventHandler(this.chkClasser_Click);
            // 
            // butHistorique
            // 
            this.butHistorique.BackColor = System.Drawing.Color.White;
            this.butHistorique.ForeColor = System.Drawing.Color.White;
            this.butHistorique.Image = ((System.Drawing.Image)(resources.GetObject("butHistorique.Image")));
            this.butHistorique.Location = new System.Drawing.Point(8, 592);
            this.butHistorique.Name = "butHistorique";
            this.butHistorique.Size = new System.Drawing.Size(32, 32);
            this.butHistorique.TabIndex = 299;
            this.butHistorique.TabStop = false;
            this.infobulle.SetToolTip(this.butHistorique, "Consultation de l\'historiques (identifiants, noms, adresses, responsables)");
            this.butHistorique.UseVisualStyleBackColor = false;
            this.butHistorique.Click += new System.EventHandler(this.butHistorique_Click);
            // 
            // butMetier
            // 
            this.butMetier.BackColor = System.Drawing.Color.White;
            this.butMetier.ForeColor = System.Drawing.Color.White;
            this.butMetier.Image = ((System.Drawing.Image)(resources.GetObject("butMetier.Image")));
            this.butMetier.Location = new System.Drawing.Point(8, 592);
            this.butMetier.Name = "butMetier";
            this.butMetier.Size = new System.Drawing.Size(32, 32);
            this.butMetier.TabIndex = 811;
            this.butMetier.TabStop = false;
            this.infobulle.SetToolTip(this.butMetier, "Gestion des données métier");
            this.butMetier.UseVisualStyleBackColor = false;
            this.butMetier.Click += new System.EventHandler(this.butMetier_Click);
            // 
            // butMessage
            // 
            this.butMessage.BackColor = System.Drawing.Color.White;
            this.butMessage.ForeColor = System.Drawing.Color.White;
            this.butMessage.Image = ((System.Drawing.Image)(resources.GetObject("butMessage.Image")));
            this.butMessage.Location = new System.Drawing.Point(950, 248);
            this.butMessage.Name = "butMessage";
            this.butMessage.Size = new System.Drawing.Size(36, 36);
            this.butMessage.TabIndex = 300;
            this.butMessage.TabStop = false;
            this.infobulle.SetToolTip(this.butMessage, "Ecrire un message concernant cette entreprise");
            this.butMessage.UseVisualStyleBackColor = false;
            this.butMessage.Click += new System.EventHandler(this.butMessage_Click);
            // 
            // cmbTypeEnt
            // 
            this.cmbTypeEnt.BackColor = System.Drawing.Color.SkyBlue;
            this.cmbTypeEnt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTypeEnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeEnt.ForeColor = System.Drawing.Color.Black;
            this.cmbTypeEnt.ImageList = this.ilsTypeEnt;
            this.cmbTypeEnt.Location = new System.Drawing.Point(128, 598);
            this.cmbTypeEnt.MaxDropDownItems = 15;
            this.cmbTypeEnt.Name = "cmbTypeEnt";
            this.cmbTypeEnt.Rempli = false;
            this.cmbTypeEnt.Size = new System.Drawing.Size(264, 22);
            this.cmbTypeEnt.TabIndex = 19;
            this.infobulle.SetToolTip(this.cmbTypeEnt, "Type d\'activité(s) de l\'entreprise");
            this.cmbTypeEnt.SelectedValueChanged += new System.EventHandler(this.cmbTypeEnt_SelectedIndexChanged);
            // 
            // cmbSecteur
            // 
            this.cmbSecteur.BackColor = System.Drawing.Color.SkyBlue;
            this.cmbSecteur.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSecteur.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSecteur.ForeColor = System.Drawing.Color.Black;
            this.cmbSecteur.ImageList = this.ilsTypeEnt;
            this.cmbSecteur.Location = new System.Drawing.Point(120, 6);
            this.cmbSecteur.MaxDropDownItems = 15;
            this.cmbSecteur.Name = "cmbSecteur";
            this.cmbSecteur.Rempli = false;
            this.cmbSecteur.Size = new System.Drawing.Size(216, 22);
            this.cmbSecteur.TabIndex = 808;
            this.infobulle.SetToolTip(this.cmbSecteur, "Type d\'activité(s) de l\'entreprise");
            this.cmbSecteur.SelectedIndexChanged += new System.EventHandler(this.cmbSecteur_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label22.Location = new System.Drawing.Point(56, 192);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 16);
            this.label22.TabIndex = 378;
            this.label22.Text = "Remarques pour";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label47.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label47.Location = new System.Drawing.Point(64, 256);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(384, 16);
            this.label47.TabIndex = 313;
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label56.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label56.Location = new System.Drawing.Point(56, 160);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(104, 16);
            this.label56.TabIndex = 378;
            this.label56.Text = "pour Tigre";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label57.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label57.Location = new System.Drawing.Point(56, 208);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(64, 16);
            this.label57.TabIndex = 378;
            this.label57.Text = "TigreWeb";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label58.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label58.Location = new System.Drawing.Point(64, 504);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(376, 16);
            this.label58.TabIndex = 313;
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label60.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.White;
            this.label60.Location = new System.Drawing.Point(392, 280);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(64, 24);
            this.label60.TabIndex = 375;
            this.label60.Text = "Tél. 24H";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTel24
            // 
            this.txtTel24.BackColor = System.Drawing.Color.White;
            this.txtTel24.ForeColor = System.Drawing.Color.Black;
            this.txtTel24.Location = new System.Drawing.Point(456, 280);
            this.txtTel24.Name = "txtTel24";
            this.txtTel24.Size = new System.Drawing.Size(96, 20);
            this.txtTel24.TabIndex = 10;
            this.txtTel24.TextChanged += new System.EventHandler(this.ModifieCommunication);
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label71.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label71.Location = new System.Drawing.Point(64, 280);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(80, 24);
            this.label71.TabIndex = 377;
            this.label71.Text = "Principaux";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label72.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label72.Location = new System.Drawing.Point(64, 392);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(88, 24);
            this.label72.TabIndex = 377;
            this.label72.Text = "Siège social";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel20.Location = new System.Drawing.Point(144, 280);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(1, 72);
            this.panel20.TabIndex = 403;
            // 
            // panel54
            // 
            this.panel54.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel54.Location = new System.Drawing.Point(776, 280);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(1, 72);
            this.panel54.TabIndex = 403;
            // 
            // panel55
            // 
            this.panel55.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel55.Location = new System.Drawing.Point(776, 416);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(1, 72);
            this.panel55.TabIndex = 403;
            // 
            // panel56
            // 
            this.panel56.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel56.Location = new System.Drawing.Point(152, 392);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(1, 96);
            this.panel56.TabIndex = 403;
            // 
            // panel57
            // 
            this.panel57.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel57.Location = new System.Drawing.Point(64, 416);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(88, 1);
            this.panel57.TabIndex = 403;
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel58.Location = new System.Drawing.Point(64, 304);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(80, 1);
            this.panel58.TabIndex = 403;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label73.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label73.Location = new System.Drawing.Point(152, 256);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(184, 16);
            this.label73.TabIndex = 404;
            this.label73.Text = "Moyens de communication";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label74.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label74.Location = new System.Drawing.Point(152, 368);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(88, 16);
            this.label74.TabIndex = 404;
            this.label74.Text = "Adresse(s)";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label75.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label75.Location = new System.Drawing.Point(152, 504);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(184, 16);
            this.label75.TabIndex = 404;
            this.label75.Text = "Autres renseignements";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label67.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.White;
            this.label67.Location = new System.Drawing.Point(56, 104);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(128, 24);
            this.label67.TabIndex = 427;
            this.label67.Text = "Ouverture juridique";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label69.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(408, 104);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(128, 24);
            this.label69.TabIndex = 426;
            this.label69.Text = "Fermeture juridique";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpOuverture
            // 
            this.dtpOuverture.Checked = false;
            this.dtpOuverture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOuverture.Location = new System.Drawing.Point(192, 104);
            this.dtpOuverture.Name = "dtpOuverture";
            this.dtpOuverture.ShowCheckBox = true;
            this.dtpOuverture.Size = new System.Drawing.Size(96, 20);
            this.dtpOuverture.TabIndex = 5;
            this.dtpOuverture.ValueChanged += new System.EventHandler(this.Modifie);
            this.dtpOuverture.Leave += new System.EventHandler(this.dtpOuverture_Leave);
            // 
            // dtpFermeture
            // 
            this.dtpFermeture.Checked = false;
            this.dtpFermeture.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFermeture.Location = new System.Drawing.Point(536, 104);
            this.dtpFermeture.Name = "dtpFermeture";
            this.dtpFermeture.ShowCheckBox = true;
            this.dtpFermeture.Size = new System.Drawing.Size(96, 20);
            this.dtpFermeture.TabIndex = 6;
            this.dtpFermeture.ValueChanged += new System.EventHandler(this.Modifie);
            this.dtpFermeture.Leave += new System.EventHandler(this.dtpFermeture_Leave);
            // 
            // txtCodeSiege
            // 
            this.txtCodeSiege.ForeColor = System.Drawing.Color.Black;
            this.txtCodeSiege.Location = new System.Drawing.Point(104, 464);
            this.txtCodeSiege.Name = "txtCodeSiege";
            this.txtCodeSiege.Size = new System.Drawing.Size(40, 20);
            this.txtCodeSiege.TabIndex = 429;
            this.txtCodeSiege.TabStop = false;
            this.txtCodeSiege.Visible = false;
            this.txtCodeSiege.TextChanged += new System.EventHandler(this.ModifieAdresse);
            // 
            // txtDtpOuverture
            // 
            this.txtDtpOuverture.BackColor = System.Drawing.Color.SkyBlue;
            this.txtDtpOuverture.ForeColor = System.Drawing.Color.Black;
            this.txtDtpOuverture.Location = new System.Drawing.Point(192, 104);
            this.txtDtpOuverture.MaxLength = 11;
            this.txtDtpOuverture.Name = "txtDtpOuverture";
            this.txtDtpOuverture.ReadOnly = true;
            this.txtDtpOuverture.Size = new System.Drawing.Size(96, 20);
            this.txtDtpOuverture.TabIndex = 1;
            this.txtDtpOuverture.TabStop = false;
            // 
            // txtDtpFermeture
            // 
            this.txtDtpFermeture.BackColor = System.Drawing.Color.SkyBlue;
            this.txtDtpFermeture.ForeColor = System.Drawing.Color.Black;
            this.txtDtpFermeture.Location = new System.Drawing.Point(536, 104);
            this.txtDtpFermeture.MaxLength = 11;
            this.txtDtpFermeture.Name = "txtDtpFermeture";
            this.txtDtpFermeture.ReadOnly = true;
            this.txtDtpFermeture.Size = new System.Drawing.Size(96, 20);
            this.txtDtpFermeture.TabIndex = 430;
            // 
            // chkPays
            // 
            this.chkPays.Checked = true;
            this.chkPays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPays.Location = new System.Drawing.Point(488, 392);
            this.chkPays.Name = "chkPays";
            this.chkPays.Size = new System.Drawing.Size(16, 16);
            this.chkPays.TabIndex = 431;
            this.chkPays.Visible = false;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label80.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.Color.White;
            this.label80.Location = new System.Drawing.Point(352, 32);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(112, 24);
            this.label80.TabIndex = 346;
            this.label80.Text = "Type d\'identifiant";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTypeIdentifiant
            // 
            this.cmbTypeIdentifiant.Location = new System.Drawing.Point(464, 32);
            this.cmbTypeIdentifiant.Name = "cmbTypeIdentifiant";
            this.cmbTypeIdentifiant.Size = new System.Drawing.Size(192, 21);
            this.cmbTypeIdentifiant.TabIndex = 435;
            this.cmbTypeIdentifiant.SelectedIndexChanged += new System.EventHandler(this.cmbTypeIdentifiant_SelectedIndexChanged);
            this.cmbTypeIdentifiant.SelectedValueChanged += new System.EventHandler(this.cmbTypeIdentifiant_SelectedIndexChanged);
            // 
            // txtTypeIdentifiant
            // 
            this.txtTypeIdentifiant.BackColor = System.Drawing.Color.SkyBlue;
            this.txtTypeIdentifiant.Location = new System.Drawing.Point(464, 32);
            this.txtTypeIdentifiant.MaxLength = 15;
            this.txtTypeIdentifiant.Name = "txtTypeIdentifiant";
            this.txtTypeIdentifiant.ReadOnly = true;
            this.txtTypeIdentifiant.Size = new System.Drawing.Size(192, 20);
            this.txtTypeIdentifiant.TabIndex = 1;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label31.Location = new System.Drawing.Point(8, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(112, 24);
            this.label31.TabIndex = 809;
            this.label31.Text = "Secteur concerné";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panChoixSecteur
            // 
            this.panChoixSecteur.Controls.Add(this.label31);
            this.panChoixSecteur.Controls.Add(this.cmbSecteur);
            this.panChoixSecteur.Controls.Add(this.panel5);
            this.panChoixSecteur.Controls.Add(this.panel7);
            this.panChoixSecteur.Controls.Add(this.panel2);
            this.panChoixSecteur.Location = new System.Drawing.Point(408, 592);
            this.panChoixSecteur.Name = "panChoixSecteur";
            this.panChoixSecteur.Size = new System.Drawing.Size(384, 40);
            this.panChoixSecteur.TabIndex = 810;
            this.panChoixSecteur.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(354, 2);
            this.panel5.TabIndex = 388;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel7.Location = new System.Drawing.Point(352, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 32);
            this.panel7.TabIndex = 388;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 2);
            this.panel2.TabIndex = 388;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(72, 598);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 24);
            this.label4.TabIndex = 809;
            this.label4.Text = "Activité";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panHistorique
            // 
            this.panHistorique.Controls.Add(this.panHistoriqueZoom);
            this.panHistorique.Controls.Add(this.lblHistoriqueZoom);
            this.panHistorique.Controls.Add(this.dagHistorique);
            this.panHistorique.Controls.Add(this.cmbHistorique);
            this.panHistorique.Controls.Add(this.label9);
            this.panHistorique.Controls.Add(this.cmbFiltre);
            this.panHistorique.Controls.Add(this.label11);
            this.panHistorique.Controls.Add(this.panel10);
            this.panHistorique.Controls.Add(this.panel28);
            this.panHistorique.Controls.Add(this.label5);
            this.panHistorique.Controls.Add(this.panel29);
            this.panHistorique.Controls.Add(this.panel30);
            this.panHistorique.Location = new System.Drawing.Point(1000, 568);
            this.panHistorique.Name = "panHistorique";
            this.panHistorique.Size = new System.Drawing.Size(880, 304);
            this.panHistorique.TabIndex = 835;
            // 
            // panHistoriqueZoom
            // 
            this.panHistoriqueZoom.Controls.Add(this.butHistoriqueZoom);
            this.panHistoriqueZoom.Controls.Add(this.txtHistoriqueZoom);
            this.panHistoriqueZoom.Location = new System.Drawing.Point(24, 200);
            this.panHistoriqueZoom.Name = "panHistoriqueZoom";
            this.panHistoriqueZoom.Size = new System.Drawing.Size(832, 88);
            this.panHistoriqueZoom.TabIndex = 468;
            // 
            // butHistoriqueZoom
            // 
            this.butHistoriqueZoom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHistoriqueZoom.Location = new System.Drawing.Point(736, 64);
            this.butHistoriqueZoom.Name = "butHistoriqueZoom";
            this.butHistoriqueZoom.Size = new System.Drawing.Size(96, 24);
            this.butHistoriqueZoom.TabIndex = 461;
            this.butHistoriqueZoom.Text = "Fermer";
            this.butHistoriqueZoom.Click += new System.EventHandler(this.butHistoriqueZoom_Click);
            // 
            // txtHistoriqueZoom
            // 
            this.txtHistoriqueZoom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistoriqueZoom.Location = new System.Drawing.Point(0, 0);
            this.txtHistoriqueZoom.Multiline = true;
            this.txtHistoriqueZoom.Name = "txtHistoriqueZoom";
            this.txtHistoriqueZoom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistoriqueZoom.Size = new System.Drawing.Size(832, 56);
            this.txtHistoriqueZoom.TabIndex = 460;
            this.txtHistoriqueZoom.Text = "Cliquez pour fermer la fenêtre";
            // 
            // lblHistoriqueZoom
            // 
            this.lblHistoriqueZoom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistoriqueZoom.Location = new System.Drawing.Point(24, 248);
            this.lblHistoriqueZoom.Name = "lblHistoriqueZoom";
            this.lblHistoriqueZoom.Size = new System.Drawing.Size(352, 16);
            this.lblHistoriqueZoom.TabIndex = 469;
            this.lblHistoriqueZoom.Text = "Cliquez sur une ligne pour voir le détail et les remarques";
            // 
            // dagHistorique
            // 
            this.dagHistorique.CaptionVisible = false;
            this.dagHistorique.DataMember = "";
            this.dagHistorique.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dagHistorique.Location = new System.Drawing.Point(24, 72);
            this.dagHistorique.Name = "dagHistorique";
            this.dagHistorique.ReadOnly = true;
            this.dagHistorique.Size = new System.Drawing.Size(832, 168);
            this.dagHistorique.TabIndex = 467;
            this.dagHistorique.Click += new System.EventHandler(this.dagHistorique_Click);
            // 
            // cmbHistorique
            // 
            this.cmbHistorique.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHistorique.Items.AddRange(new object[] {
            "Noms",
            "Adresses",
            "Identifiants",
            "Responsables"});
            this.cmbHistorique.Location = new System.Drawing.Point(152, 32);
            this.cmbHistorique.Name = "cmbHistorique";
            this.cmbHistorique.Size = new System.Drawing.Size(200, 24);
            this.cmbHistorique.TabIndex = 466;
            this.cmbHistorique.Text = "Noms";
            this.cmbHistorique.SelectedIndexChanged += new System.EventHandler(this.cmbHistorique_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 24);
            this.label9.TabIndex = 463;
            this.label9.Text = "Type d\'historique";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFiltre
            // 
            this.cmbFiltre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltre.Location = new System.Drawing.Point(536, 32);
            this.cmbFiltre.Name = "cmbFiltre";
            this.cmbFiltre.Size = new System.Drawing.Size(200, 24);
            this.cmbFiltre.TabIndex = 465;
            this.cmbFiltre.SelectedIndexChanged += new System.EventHandler(this.cmbFiltre_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(400, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 24);
            this.label11.TabIndex = 464;
            this.label11.Text = "Filtre sur les données";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel10.Location = new System.Drawing.Point(8, 24);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(866, 2);
            this.panel10.TabIndex = 449;
            // 
            // panel28
            // 
            this.panel28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel28.Location = new System.Drawing.Point(8, 24);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(2, 272);
            this.panel28.TabIndex = 448;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(880, 16);
            this.label5.TabIndex = 447;
            this.label5.Text = "Historique des données";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel29
            // 
            this.panel29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel29.Location = new System.Drawing.Point(872, 24);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(2, 272);
            this.panel29.TabIndex = 448;
            // 
            // panel30
            // 
            this.panel30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(189)))), ((int)(((byte)(31)))));
            this.panel30.Location = new System.Drawing.Point(8, 296);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(866, 2);
            this.panel30.TabIndex = 449;
            // 
            // FrmEntp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(146)))));
            this.ClientSize = new System.Drawing.Size(990, 904);
            this.ControlBox = false;
            this.Controls.Add(this.panHistorique);
            this.Controls.Add(this.panSecteur);
            this.Controls.Add(this.butGestionIdentifiant);
            this.Controls.Add(this.butID);
            this.Controls.Add(this.butCopieRemarques);
            this.Controls.Add(this.chkPays);
            this.Controls.Add(this.txtCodeSiege);
            this.Controls.Add(this.txtMel);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtSIREN);
            this.Controls.Add(this.txtAdr1Siege);
            this.Controls.Add(this.txtAdr2Siege);
            this.Controls.Add(this.txtKbis);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtTel24);
            this.Controls.Add(this.dtpFermeture);
            this.Controls.Add(this.dtpOuverture);
            this.Controls.Add(this.txtDtpFermeture);
            this.Controls.Add(this.txtDtpOuverture);
            this.Controls.Add(this.txtTypeIdentifiant);
            this.Controls.Add(this.txtCommentairesTigre);
            this.Controls.Add(this.txtCommentairesWeb);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label75);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panAdresse3);
            this.Controls.Add(this.panel40);
            this.Controls.Add(this.panEL);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butFermer);
            this.Controls.Add(this.cmbFJ);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblEntp);
            this.Controls.Add(this.lblSIREN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butDicoFJ);
            this.Controls.Add(this.lblFJ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAdr1);
            this.Controls.Add(this.butCommunication);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lblMetier);
            this.Controls.Add(this.butAdresse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.butSousTraitant);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.butRechercher);
            this.Controls.Add(this.butImprimer);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.panel54);
            this.Controls.Add(this.panel55);
            this.Controls.Add(this.panel56);
            this.Controls.Add(this.panel57);
            this.Controls.Add(this.panel58);
            this.Controls.Add(this.butMajCmbFJ);
            this.Controls.Add(this.butEtablissement);
            this.Controls.Add(this.butNouveau);
            this.Controls.Add(this.butSupprimer);
            this.Controls.Add(this.butSauver);
            this.Controls.Add(this.butModifier);
            this.Controls.Add(this.butResponsable);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.cmbTypeIdentifiant);
            this.Controls.Add(this.chkVerifier);
            this.Controls.Add(this.chkValider);
            this.Controls.Add(this.chkClasser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbTypeEnt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panChoixSecteur);
            this.Controls.Add(this.butHistorique);
            this.Controls.Add(this.butMetier);
            this.Controls.Add(this.butMessage);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmEntp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Données de l\'entreprise";
            this.panSecteur.ResumeLayout(false);
            this.panSecteur.PerformLayout();
            this.panCommentairesWebSecteur.ResumeLayout(false);
            this.panCommentairesWebSecteur.PerformLayout();
            this.panEL.ResumeLayout(false);
            this.panEL.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panAdresse3.ResumeLayout(false);
            this.panAdresse3.PerformLayout();
            this.panCedexSiege.ResumeLayout(false);
            this.panCedexSiege.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panChoixSecteur.ResumeLayout(false);
            this.panHistorique.ResumeLayout(false);
            this.panHistoriqueZoom.ResumeLayout(false);
            this.panHistoriqueZoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dagHistorique)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Méthodes de IFormulaireTigre

		public void MettreAJour()
		{
			if (_existante) IndiquerFinModif();
            int n = cmbTypeEnt.SelectedIndex;
            cmbTypeEnt.SelectedIndex = 0;
            cmbTypeEnt.SelectedIndex = n;
			OuvrirValidation();
		}

		public void Fermer(bool premiereCible, bool maj)
		{
			comportement.Fermer(premiereCible,maj);
			this.Close();
		}

		public void PeutChanger()
		{
			comportement.PeutChanger();
		}

		public bool AChange()
		{
			return (_modifie||_modifieID||_modifieAdresse||_modifieComm||_modifieSecteur);
		}

		public void IndiquerModif()
		{
			comportement.IndiquerModif();
		}

		public void IndiquerFinModif()
		{
			_modifie = false;
			_modifieID = false;
			_modifieAdresse = false;
			_modifieComm = false;
			_modifieSecteur = false;
		}

		public void Initialise()
		{
			comportement.Initialise();
		}

		public void Verrouille()
		{
			comportement.Verrouille();
			comportement.Verrouille(ChampsSecteur);
		}

		public void Deverrouille()
		{
			comportement.Deverrouille();
            if (FBase.PeutModifier(10))
            {
                comportement.Deverrouille(ChampsSecteur);
                if (codeResponsable == 0) comportement.Verrouille(cmbPRSecteur);
            }
		}

		#endregion	

		#region Membres de IRechercheEntreprise

		public void OuvrirEntreprise(int code, TypeActivite activite)
		{
			codeEntreprise = code;
			_existante = true;
			try
			{
				DataTable maTable = FBase.EnvoyerProcedure("p_tigre_ouvreEntreprise",(int)TypeActivite.Neutre + "," + code);
				DataRow resultat = maTable.Rows[0];
				int[] lesChamps = new int[]{(int)OuvreEntreprise.Siren,
											   (int)OuvreEntreprise.Kbis,
											   (int)OuvreEntreprise.CodeFormeJuridique,
											   (int)OuvreEntreprise.Nom,
											   (int)OuvreEntreprise.CommentairesTigre,
											   (int)OuvreEntreprise.CommentairesWeb};
				comportement.AfficherDetail(resultat, CiblesEntreprise(), lesChamps);
				strAncienID = CEncodeur.libRecherche(txtSIREN.Text);
				maTable = FBase.EnvoyerProcedure("p_tigre_ouvreIdentifiant",(int)Entite.Entreprise+",'"+strAncienID+"'");
				cmbTypeIdentifiant.SelectedValue = Convert.ToInt32(maTable.Rows[0].ItemArray[(int)OuvreIdentifiant.CodeType]);
				OuvrirDate();
				OuvrirCommunication();
				OuvrirAdresse(Entite.Entreprise);
				OuvrirActivites();
				OuvrirValidation();
				IndiquerFinModif();
				butGestionIdentifiant.Visible = true;
				if(cmbTypeEnt.SelectedIndex>0) MettreAJour();
//				cmbTypeEnt.SelectedIndex = 0;
			}
			catch(Exception exc)
			{
				MessageBox.Show("Impossible d'ouvrir cette entreprise ("+code+")\n" + exc.Message,"TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Error);
				codeEntreprise = 0;
				_existante = false;
			}
		}

		public void OuvrirEntreprise(int code)
		{
			OuvrirEntreprise(code,TypeActivite.Neutre);
		}

		#endregion

		# region Fonctions privées

		private void Monte()
		{
			codeSecteur = 0;
			panChoixSecteur.Visible = false;
			panSecteur.Top = -800;
		}

		private string Arguments(bool existante)
		{
			StringBuilder arg;
			if(!existante) strAncienID = txtSIREN.Text;
			arg = new StringBuilder((int)TypeActivite.Neutre + ",'" + strAncienID + "','" + txtKbis.Text + "'," + cmbFJ.SelectedValue);
			arg.Append(@",""" + txtNom.Text.Replace(@"""","''") + @"""");
			arg.Append(@",""" + txtCommentairesTigre.Text.Replace(@"""","''") + @"""");
			arg.Append(@",""" + txtCommentairesWeb.Text.Replace(@"""","''") + @"""");
			return arg.ToString();
		}

		private string ArgumentsAdresse()
		{
			StringBuilder arg;
			arg = new StringBuilder((int)Entite.Entreprise + "," + codeEntreprise + ",0,1,1"); 
			// le 0 car ce n'est pas une modif. a priori, le 1er 1 pour le type d'adr. (siège), le 2ème car c'est l'adr. principale
			arg.Append(@",""" + txtAdr1Siege.Text.Replace(@"""","''") + @"""");
			arg.Append(@",""" + txtAdr2Siege.Text.Replace(@"""","''") + @"""");
			if(chkCedexSiege.Checked) arg.Append(",'"+txtCedexSiege.Text+"'"); else arg.Append(",NULL");
			if(rbAdresseFrance.Checked) arg.Append(",1"); else arg.Append(",0");
			arg.Append(","+txtCodeSiege.Text + ",''");
			return arg.ToString();
		}

		private bool IdentifiantValable()
		{
			bool valable = false;
			string IdTest = CEncodeur.libRecherche(txtSIREN.Text.Trim());
			if(IdTest.Substring(0,1)=="A") valable = (IdTest.Length==8);
			else valable = (IdTest.Length==9);
			return valable;
		}

		private void VerifieSaisie()
		{
			if(txtCodeSiege.Text=="" || txtCodeSiege.Text=="0") 
				throw new Exception("la ville du siège ne peut pas être vide");
		}

		#region Secteurs

		private string ArgumentsSecteur()
		{
			StringBuilder arg;
			arg = new StringBuilder(codeSecteur + ",'" + txtSIREN.Text + "',NULL,NULL"); 
			arg.Append(@",""" + txtNomSecteur.Text.Replace(@"""","''") + @"""");
			arg.Append(@",""" + txtCommentairesTigreSecteur.Text.Replace(@"""","''") + @"""");
			arg.Append(@",""" + txtCommentairesWebSecteur.Text.Replace(@"""","''") + @"""");
			return arg.ToString();
		}

		private string ArgumentsPRSecteur()
		{
			StringBuilder arg;
			arg = new StringBuilder((int)Entite.Entreprise + "," + codeEntreprise); 
			arg.Append("," + codeResponsable + "," + cmbPRSecteur.SelectedValue + ",'',1");
			return arg.ToString();
		}

        private bool MontreDonneesSecteur()
        {
            DataTable dt = FBase.EnvoyerProcedure("p_tigre_ouvreCaracteristique", (int)Entite.Entreprise + "," + codeEntreprise);
            DataRow[] dr = dt.Select("tact_codeTerme=" + codeSecteur);
            bool nouvelle = !Convert.ToBoolean(dr[0].ItemArray[1]);
            if ((!nouvelle || (nouvelle && PeutValider() && FBase.AProfil(10))))
            {
                panSecteur.Top = 624;
                panSecteur.BringToFront();
                if (FBase != null)
                {
                    Cursor = Cursors.WaitCursor;
                    FrmDictionnaire fDico = new FrmDictionnaire(FBase);
                    fDico.RemplisTypes();
                    fDico.GetDico("Personne");
                    fDico = null;
                    cmbPRSecteur.DataSource = FBase.TablesDeReference.Tables["Personne"].Copy();
                    cmbPRSecteur.DisplayMember = "pers_identite";
                    cmbPRSecteur.ValueMember = "pers_num_pk";
                    cmbPRSecteur.SelectedValue = 0;
                    FBase.OterCible(true, false);
                    Cursor = Cursors.Default;
                }
                dt = FBase.EnvoyerProcedure("p_tigre_ouvreEntreprise", codeSecteur + "," + codeEntreprise);
                dr = dt.Select("secteur=" + codeSecteur);
                object[] arIt;
                if ((codeEntreprise > 0) && (dt.Rows.Count > 0))
                {
                    if (dr.Length > 0) arIt = dt.Rows[0].ItemArray;
                    else arIt = new object[]{codeEntreprise,"","",txtSIREN.Text,"",
												dt.Rows[0].ItemArray[(int)OuvreEntreprise.Nom].ToString(),"","",""};
                }
                else arIt = new object[] { codeEntreprise, "", "", txtSIREN.Text, "", txtNom.Text, "", "", "" };
                txtNomSecteur.Text = arIt[(int)OuvreEntreprise.Nom].ToString();
                txtCommentairesTigreSecteur.Text = arIt[(int)OuvreEntreprise.CommentairesTigre].ToString();
                txtCommentairesWebSecteur.Text = arIt[(int)OuvreEntreprise.CommentairesWeb].ToString();
                OuvrirDateSecteur();
                dt = FBase.EnvoyerProcedure("p_tigre_ouvreResponsable", (int)Entite.Entreprise + "," + codeEntreprise);
                dr = dt.Select("trsp_codeTerme=" + codeResponsable);
                if (dr.Length > 0)
                    cmbPRSecteur.SelectedValue = Convert.ToInt32(dr[0].ItemArray[(int)OuvreResponsable.CodePersonne]);
                else
                    cmbPRSecteur.SelectedValue = 0;
                if (codeResponsable == 0) comportement.Verrouille(cmbPRSecteur);
                IndiquerFinModif();

                if (nouvelle)
                {
                    DialogResult chx = DialogResult.OK;
                    chx = MessageBox.Show("Vous allez créer la caractéristique de cette activité pour cette entreprise "
                        + "(désormais, elle apparaîtra dans les listes d'entreprises exerçant - ou ayant exercé - cette activité, même si elle est non active).\nContinuer ?",
                        "TIGRE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (chx == DialogResult.OK)
                    {
                        if (nouvelle) ModifieSecteur(this, null);
                        txtNomSecteur.Focus();
                        return nouvelle;
                    }
                    else
                    {
                        Monte();
                        Verrouille();
                        IndiquerFinModif();
                        return false;
                    }
                }
                else return false;
            }
            else
            {
                MessageBox.Show("Vos droits d'utilisation ne vous permettent pas d'enregistrer une nouvelle activité", "TIGRE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Monte();
                Verrouille();
                IndiquerFinModif();
                return false;
            }
        }

		private void OuvrirDateSecteur()
		{
			DataTable dtDate = FBase.EnvoyerProcedure("p_tigre_ouvreActivite",codeSecteur+","+(int)Entite.Entreprise+","+codeEntreprise);
			DataRow drDate = dtDate.Rows[0];
			try
			{
				txtEtatSecteur.Text = drDate.ItemArray[(int)OuvreActivite.Etat].ToString();
				txtOuvertureSecteur.Text = Convert.ToDateTime(drDate.ItemArray[(int)OuvreActivite.DateDebut]).ToShortDateString();
//				txtFermeturePh.Text = Convert.ToDateTime(drDate.ItemArray[(int)OuvreActivite.DateFin]).ToShortDateString();
			}
			catch {}
		}

        private void VerifieSaisieSecteur()
        {
            if (codeSecteur == (int)TypeActivite.Pharmaceutique)
                if ((chkPays.Checked) && (Convert.ToInt32(cmbPRSecteur.SelectedValue) == 0))
                    throw new Exception("Erreur d'enregistrement pharmaceutique : vous devez sélectionner un pharmacien responsable");
        }

		#endregion

		private void GetFont()
		{
			fontGras = rbAdresseFrance.Font;
			fontNormal = rbAdresseEtranger.Font;
		}

		private Control[] CiblesEntreprise()
		{
			Control[] mesControl = new Control[6];
			mesControl[0] = txtSIREN;
			mesControl[1] = txtKbis;
			mesControl[2] = cmbFJ;
			mesControl[3] = txtNom;
			mesControl[4] = txtCommentairesTigre;
			mesControl[5] = txtCommentairesWeb;
			return mesControl;
		}

		private Control[] CiblesSiege()
		{
			Control[] cibles = new Control[8];
			cibles[0] = txtAdr1Siege;
			cibles[1] = txtAdr2Siege;
			cibles[2] = txtCPSiege;
			cibles[3] = txtCodeSiege;
			cibles[4] = txtVilleSiege;
			cibles[5] = chkCedexSiege;
			cibles[6] = txtCedexSiege;
			cibles[7] = chkPays;
			return cibles;
		}

		private object[] DicoDeRecherche(Control sender)
		{
			int monDico = 0;
			string selection;
			string monCritere = "";
			string libRech = "";
			DataRow[] monEnr;
			DataTable maTable;
			switch(sender.Name)
			{
				case "butDicoFJ" :
					selection = "dico_table = 'FormeJuridique'";
					monEnr = FBase.TablesDeReference.Tables["DicoDico"].Select(selection);
					monDico = Convert.ToInt32(monEnr[0].ItemArray[0]);
					maTable = FBase.EnvoyerProcedure("p_tigre_TraiteLibRech","\""+cmbFJ.Text.Replace("\"","''")+"\"");
					libRech = maTable.Rows[0].ItemArray[0].ToString();
					if(libRech=="---") libRech="";
					monCritere = "fjur_libRech like '"+libRech+"%'";
					break;
				case "butDicoPersonne" :
					selection = "dico_table = 'Personne'";
					monEnr = FBase.TablesDeReference.Tables["DicoDico"].Select(selection);
					monDico = Convert.ToInt32(monEnr[0].ItemArray[0]);
					maTable = FBase.EnvoyerProcedure("p_tigre_TraiteLibRech","\""+cmbPRSecteur.Text.Replace("\"","''")+"\"");
					libRech = maTable.Rows[0].ItemArray[0].ToString();
					if(libRech=="---") libRech="";
					monCritere = "pers_libRech like '"+libRech+"%'";
					break;
			}
			return new object[]{monDico,monCritere};
		}

		private DialogResult SauvegarderAvant()
		{
			if(AChange())
			{
				DialogResult chx = MessageBox.Show("L'entreprise doit être sauvegardée pour faire ceci.\n Enregistrer ?",
					"TIGRE",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if(chx==DialogResult.Yes)
				{
					try
					{
						butSauver.PerformClick();
					}
					catch(Exception)
					{ 
						return DialogResult.No;
					}
				}
				return chx;
			}
			return DialogResult.Yes;
		}

		private int SauverSecteur()
		{
			DataTable maTable=null;
			_existante = (codeEntreprise!=0);
			bool enregistrement = AChange();
			if(!IdentifiantValable())
			{
				MessageBox.Show("Cet identifiant n'est pas valable ; enregistrement annulé.","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Error);
				return codeEntreprise;
			}
			else 
			{
				try
				{
					try
					{
						if((codeEntreprise==0)||_modifie)
						{
							VerifieSaisie();
							maTable = FBase.EnvoyerProcedure(comportement.ProcEnregistrement,Arguments(_existante));
							if(maTable!=null) codeEntreprise=Convert.ToInt32(maTable.Rows[0].ItemArray[0]);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message+" ; enregistrement annulé","TIGRE",
							MessageBoxButtons.OK,MessageBoxIcon.Error);
						return codeEntreprise;
					}
					if(!_existante)
					{
						if(txtSIREN.Text.IndexOf("A")>0)
						{
							MessageBox.Show("Les identifiants Afssaps sont enregistrés comme temporaires, et leur période de validité et de 3 mois.",
								"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Information);
							FBase.EnvoyerProcedure("p_tigre_svIdentifiant",(int)Entite.Entreprise+","+codeEntreprise+","+cmbTypeIdentifiant.SelectedValue+",'"+txtSIREN.Text+"','"+CEncodeur.DateAm(DateTime.Now.AddMonths(3))+"'");
						}
						else
							FBase.EnvoyerProcedure("p_tigre_svIdentifiant",(int)Entite.Entreprise+","+codeEntreprise+","+cmbTypeIdentifiant.SelectedValue+",'"+txtSIREN.Text+"',NULL");
					}
					if(_modifie) SauverDate();
					if(_modifieComm) SauverCommunication();
					if(_modifieAdresse) SauverAdresse();
					if(_modifieSecteur)
					{
						if(FBase.AProfil(10))
						{
                            try
                            {
                                VerifieSaisieSecteur();
                                FBase.EnvoyerProcedure(comportement.ProcEnregistrement, ArgumentsSecteur());
                                if (codeResponsable > 0)
                                {
                                    if (cmbPRSecteur.SelectedIndex > 0)
                                        FBase.EnvoyerProcedure("p_tigre_svResponsable", ArgumentsPRSecteur());
                                    else
                                        FBase.EnvoyerProcedure("p_tigre_supprResponsableType", (int)Entite.Entreprise + "," + codeEntreprise + "," + codeResponsable);
                                }
                                _modifieSecteur = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + " ; enregistrement du statut/de l'activité annulé", "TIGRE",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
						}
						else
						{
							MessageBox.Show("Vos droits d'utilisation ne vous permettent pas d'enregistrer les activités","TIGRE",
								MessageBoxButtons.OK,MessageBoxIcon.Warning);
						}
					}
					if(enregistrement) 						
						MessageBox.Show("Entreprise sauvegardée","TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Information);
					IndiquerFinModif();
					return codeEntreprise;
				}
				catch(Exception e)
				{
					MessageBox.Show("Erreur d'enregistrement : " + e.Message,"TIGRE",
						MessageBoxButtons.OK,MessageBoxIcon.Error);
					return 0;
				}
			}
		}

		private void SupprimerSecteur()
		{
//			if(codeEntreprise==0) 
//				MessageBox.Show("Vous devez sélectionner une entreprise","TIGRE",
//					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
//			else
//			{
//				MessageBox.Show("Etes-vous sûr de vouloir supprimer cette activité ?","TIGRE",
//					MessageBoxButtons.OK,MessageBoxIcon.Question);
//				DataTable dtSuppression = FBase.EnvoyerProcedure(comportement.ProcSuppression+libCourt,codeEntreprise+",1");
//				switch(Convert.ToInt32(dtSuppression.Rows[0].ItemArray[0]))
//				{
//					case 0:
//						MessageBox.Show("Activité "+libLong+" supprimée","TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Information);
//						IndiquerFinModif();
//						((ComboBoxExItem)cmbTypeEnt.SelectedItem).ImageIndex=0;
//						cmbTypeEnt.SelectedIndex = 0;
//						cmbTypeEnt.Focus();
//						break;
//					default:
//						DialogResult chx = MessageBox.Show("Cette entreprise possède encore des établissements ayant cette activité; voulez-vous la supprimer pour tous ?","TIGRE",
//							MessageBoxButtons.YesNo,MessageBoxIcon.Question);
//						if(chx==DialogResult.Yes)
//						{
//							FBase.EnvoyerProcedure(comportement.ProcSuppression+libCourt,codeEntreprise+",0");
//							MessageBox.Show("Activité "+libLong+" supprimée","TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Information);
//							((ComboBoxExItem)cmbTypeEnt.SelectedItem).ImageIndex=0;
//							cmbTypeEnt.SelectedIndex = 0;
//							cmbTypeEnt.Focus();
//						}
//						break;
//				}
//			}
		}

		private void OuvrirDate()
		{
			DataTable dtDate;
			DataRow[] vlDate;
			dtDate = FBase.EnvoyerProcedure("p_tigre_ouvreDate",(int)Entite.Entreprise+","+codeEntreprise);
			vlDate = dtDate.Select("tdte_codeTerme=1 and tact_codeTerme="+(int)TypeActivite.Neutre);
			if(vlDate.Length>0) 
			{
				codeDateOuverture = Convert.ToInt32(vlDate[0].ItemArray[(int)OuvreDate.Code]);
				dtpOuverture.Value = Convert.ToDateTime(vlDate[0].ItemArray[(int)OuvreDate.Date]);
				txtDtpOuverture.Text = Convert.ToDateTime(vlDate[0].ItemArray[(int)OuvreDate.Date]).ToShortDateString();
			}
			vlDate = dtDate.Select("tdte_codeTerme=2 and tact_codeTerme="+(int)TypeActivite.Neutre);
			if(vlDate.Length>0)
			{
				codeDateFermeture = Convert.ToInt32(vlDate[0].ItemArray[(int)OuvreDate.Code]);
				dtpFermeture.Value = Convert.ToDateTime(vlDate[0].ItemArray[(int)OuvreDate.Date]);
				txtDtpFermeture.Text = Convert.ToDateTime(vlDate[0].ItemArray[(int)OuvreDate.Date]).ToShortDateString();
			}
		}

		private void SauverDate()
		{
			if(dtpOuverture.Checked)
				FBase.EnvoyerProcedure("p_tigre_svDate",
					(int)Entite.Entreprise+","+codeEntreprise+",1,"+(int)TypeActivite.Neutre+",'"+CEncodeur.DateAm(dtpOuverture.Value)+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprDate",(int)Entite.Entreprise+","+codeDateOuverture);
			if(dtpFermeture.Checked)
				FBase.EnvoyerProcedure("p_tigre_svDate",
					(int)Entite.Entreprise+","+codeEntreprise+",2,"+(int)TypeActivite.Neutre+",'"+CEncodeur.DateAm(dtpFermeture.Value)+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprDate",(int)Entite.Entreprise+","+codeDateFermeture);
		}

		private void OuvrirCommunication()
		{
			DataTable dtCommunication;
			DataRow[] comm;
			dtCommunication = FBase.EnvoyerProcedure("p_tigre_ouvreCommunication",(int)Entite.Entreprise+","+codeEntreprise);
			comm = dtCommunication.Select("cmen_principale=1 and tcom_codeTerme=1");
			if(comm.Length>0) 
			{
				codeTel = Convert.ToInt32(comm[0].ItemArray[(int)OuvreCommunication.Code]);
				txtTel.Text = comm[0].ItemArray[(int)OuvreCommunication.Detail].ToString();
			}
			comm = dtCommunication.Select("cmen_principale=1 and tcom_codeTerme=2");
			if(comm.Length>0) 
			{
				codeFax = Convert.ToInt32(comm[0].ItemArray[(int)OuvreCommunication.Code]);
				txtFax.Text = comm[0].ItemArray[(int)OuvreCommunication.Detail].ToString();
			}
			comm = dtCommunication.Select("cmen_principale=1 and tcom_codeTerme=3");
			if(comm.Length>0) 
			{
				codeMel = Convert.ToInt32(comm[0].ItemArray[(int)OuvreCommunication.Code]);
				txtMel.Text = comm[0].ItemArray[(int)OuvreCommunication.Detail].ToString();
			}
			comm = dtCommunication.Select("cmen_principale=1 and tcom_codeTerme=4");
			if(comm.Length>0) 
			{
				codeUrl = Convert.ToInt32(comm[0].ItemArray[(int)OuvreCommunication.Code]);
				txtUrl.Text = comm[0].ItemArray[(int)OuvreCommunication.Detail].ToString();
			}
			comm = dtCommunication.Select("cmen_principale=1 and tcom_codeTerme=5");
			if(comm.Length>0) 
			{
				codeTel24 = Convert.ToInt32(comm[0].ItemArray[(int)OuvreCommunication.Code]);
				txtTel24.Text = comm[0].ItemArray[(int)OuvreCommunication.Detail].ToString();
			}
		}

		private void SauverCommunication()
		{
			if(txtTel.Text.Trim()!="")
				FBase.EnvoyerProcedure("p_tigre_svCommunication",
					(int)Entite.Entreprise+","+codeEntreprise+",0,1,'"+txtTel.Text+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprCommunication",(int)Entite.Entreprise+","+codeTel);
			if(txtFax.Text.Trim()!="")
				FBase.EnvoyerProcedure("p_tigre_svCommunication",
					(int)Entite.Entreprise+","+codeEntreprise+",0,2,'"+txtFax.Text+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprCommunication",(int)Entite.Entreprise+","+codeFax);
			if(txtMel.Text.Trim()!="")
				FBase.EnvoyerProcedure("p_tigre_svCommunication",
					(int)Entite.Entreprise+","+codeEntreprise+",0,3,'"+txtMel.Text+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprCommunication",(int)Entite.Entreprise+","+codeMel);
			if(txtUrl.Text.Trim()!="")
				FBase.EnvoyerProcedure("p_tigre_svCommunication",
					(int)Entite.Entreprise+","+codeEntreprise+",0,4,'"+txtUrl.Text+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprCommunication",(int)Entite.Entreprise+","+codeUrl);
			if(txtTel24.Text.Trim()!="")
				FBase.EnvoyerProcedure("p_tigre_svCommunication",
					(int)Entite.Entreprise+","+codeEntreprise+",0,5,'"+txtTel24.Text+"','',1");
			else FBase.EnvoyerProcedure("p_tigre_supprCommunication",(int)Entite.Entreprise+","+codeTel24);
			_modifieComm = false;
		}

		private void OuvrirAdresse(Entite entite)
		{
			DataTable maTable=null;
			DataRow[] dtTable;
			DataRow adresse;
			string pref = "";
			try
			{
				switch(entite)
				{
					case Entite.Entreprise:
						maTable = FBase.EnvoyerProcedure("p_tigre_ouvreAdresse",(int)Entite.Entreprise+","+codeEntreprise);
						pref = "aden";
						break;
					case Entite.Etablissement:
						maTable = FBase.EnvoyerProcedure("p_tigre_ouvreAdresse",(int)Entite.Etablissement+","+codeAdresse);
						pref = "adet";
						break;
				}
				dtTable = maTable.Select(pref+"_principale=1");
				adresse = dtTable[0];
				codeAdresse = Convert.ToInt32(adresse.ItemArray[(int)OuvreAdresse.Code]);
				int[] champs = new int[]{(int)OuvreAdresse.Adresse1,
											(int)OuvreAdresse.Adresse2,
											(int)OuvreAdresse.CodePostal,
											(int)OuvreAdresse.CodeVille,
											(int)OuvreAdresse.Ville,
											(int)OuvreAdresse.ACedex,
											(int)OuvreAdresse.Cedex,
											(int)OuvreAdresse.EnFrance};
				comportement.AfficherDetail(adresse,CiblesSiege(),champs);
//				if(!chkPays.Checked)
//				{
//					string _codeville = txtCodeSiege.Text;
//					string _codepostal = txtCPSiege.Text;
//					string _ville = txtVilleSiege.Text;
//					rbAdresseEtranger.Checked =  true;
//					rbAdresseEtranger_Click(this,null);
//					txtCPSiege.Text = _codepostal;
//					txtCodeSiege.Text = _codeville;
//					txtVilleSiege.Text = _ville;
//				}
				ChangePays();
			}
			catch
			{
				MessageBox.Show("Impossible d'ouvrir l'adresse","TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void SauverAdresse()
		{
			FBase.EnvoyerProcedure("p_tigre_svAdresse",ArgumentsAdresse());
			_modifieAdresse = false;
		}

		private void OuvrirActivitesDefaut()
		{
			int[] arIndex = new int[FBase.TablesDeReference.Tables["Activite"].Rows.Count+1];
			for(int i =0;i<arIndex.Length;i++) arIndex[i]=0;
			arIndex[0]=1;
			cmbTypeEnt.ImageIndex = arIndex;
			cmbTypeEnt.ImageList = ilsTypeEnt;
			// not needed but... no icon for index -1 else
			cmbTypeEnt.DropDownStyle = ComboBoxStyle.DropDownList;
			// just pass these in instead of strings, class included below
			// specify a valid imageIndex
			cmbTypeEnt.SelectedIndex = 0;
		}

		private void OuvrirActiviteSecteur()
		{
			DataTable dtActivites = FBase.EnvoyerProcedure("p_tigre_ouvreCaracteristique",(int)Entite.Entreprise+","+codeEntreprise);
			int[] arActivites = new int[FBase.TablesDeReference.Tables["Activite"].Rows.Count];
			arActivites[0] = 1;
			cmbSecteur.ImageList = ilsTypeEnt;
			cmbTypeEnt.ImageIndex = arActivites;
			// not needed but... no icon for index -1 else
			cmbSecteur.DropDownStyle = ComboBoxStyle.DropDownList;
			// just pass these in instead of strings, class included below
			// specify a valid imageIndex
			cmbSecteur.Rempli = true;
			cmbSecteur.SelectedIndex = 0;
		}

		private void OuvrirActivites()
		{
			int i = cmbTypeEnt.SelectedIndex;
			DataTable dtActivites = FBase.EnvoyerProcedure("p_tigre_ouvreCaracteristique",(int)Entite.Entreprise+","+codeEntreprise);
			int[] arActivites = new int[FBase.TablesDeReference.Tables["Activite"].Rows.Count+1];
			arActivites[0] = 1;
			DataRow[] arDr;
			int j = 1;
			foreach(DataRow dr in FBase.TablesDeReference.Tables["Activite"].Rows)
			{
				arDr = dtActivites.Select("tact_codeTerme="+dr.ItemArray[(int)TIGRE.SelectTermeReference.CodeTerme]);
				if(Convert.ToBoolean(arDr[0].ItemArray[(int)OuvreCaracteristique.Presente])) arActivites[j] = 1; 
                else arActivites[j] = 0;
				j++;
			}
			cmbTypeEnt.ImageList = ilsTypeEnt;
			cmbTypeEnt.ImageIndex = arActivites;
			// not needed but... no icon for index -1 else
			cmbTypeEnt.DropDownStyle = ComboBoxStyle.DropDownList;
			// just pass these in instead of strings, class included below
			// specify a valid imageIndex
			cmbTypeEnt.Rempli = true;
			cmbTypeEnt.SelectedIndex = i;
		}

		private void OuvrirValidation()
		{
			messageStatut = new int[3];
			bool blDonneesDIE = false;
			DateTime dtValide = DateTime.MinValue;
			IndiquerClassement();
			dtValidation = FBase.EnvoyerProcedure("p_tigre_ouvreValidationDonnees",(int)Entite.Entreprise+","+codeEntreprise);
			DataRow[] drValidation = dtValidation.Select("vlen_statut_fk=1");
			if((dtValidation.Rows.Count==0)||drValidation.Length>0)
			{
				blDonneesDIE = true;
				if(dtValidation.Rows.Count>0) dtValide = Convert.ToDateTime(drValidation[0].ItemArray[(int)OuvreValidationDonnees.Date]);
			}
			drValidation = dtValidation.Select("vlen_statut_fk=3 and vlen_date>'"+dtValide.ToShortDateString()+"'");
			if(drValidation.Length>0)
			{
				blDonneesDIE = true;
				IndiquerVerification();
				dtValide = Convert.ToDateTime(drValidation[0].ItemArray[(int)OuvreValidationDonnees.Date]);
				messageStatut[0] = Convert.ToInt16(drValidation[0].ItemArray[(int)OuvreValidationDonnees.CodeMessage]);
			}
			else
			{
				chkVerifier.Checked = false;
				messageStatut[0] = 0;
			}
			drValidation = dtValidation.Select("vlen_statut_fk=2 and vlen_date>'"+dtValide.ToShortDateString()+"'");
			if(drValidation.Length>0)
			{
				blDonneesDIE = true;
				IndiquerValidation();
				messageStatut[1] = Convert.ToInt16(drValidation[0].ItemArray[(int)OuvreValidationDonnees.CodeMessage]);
			}
			else
			{
				chkValider.Checked = false;
				messageStatut[1] = 0;
			}
			if(!blDonneesDIE)
			{
				drValidation = dtValidation.Select("vlen_statut_fk not in (1,2,3)","vlen_date desc");
				if(drValidation.Length>0)
				{
                    string statut = drValidation[0].ItemArray[(int)OuvreValidationDonnees.Statut].ToString();
                    string proprietaire = drValidation[0].ItemArray[(int)OuvreValidationDonnees.Proprietaire].ToString();
					IndiquerInformationNonDIE(statut, proprietaire);
					messageStatut[2] = Convert.ToInt16(drValidation[0].ItemArray[(int)OuvreValidationDonnees.CodeMessage]);
				}
			}
		}

        private bool PeutValider()
        {
            bool sauver = false;
            if ((dtValidation == null) || (dtValidation.Rows.Count == 0))
            {
                sauver = (FBase.TablesDeReference.Tables["Validation"].Rows.Count == 0);
                sauver |= ((codeEntreprise == 0) || (FBase.TablesDeReference.Tables["Validation"].Select("dvut_statut_fk=1").Length > 0));
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in FBase.TablesDeReference.Tables["Validation"].Rows)
                {
                    sb.Append("," + dr.ItemArray[2].ToString());
                    if (Convert.ToInt32(dr.ItemArray[2]) == 1) sauver = true;
                }
                if (!sauver && (sb.Length > 0))
                {
                    sb.Remove(0, 1);
                    DateTime dateValidation = Convert.ToDateTime(dtValidation.Compute("max(vlen_date)", "vlen_statut_fk>0"));
                    string tri = "vlen_date>='" + dateValidation.ToString() + "' and vlen_statut_fk not in (" + sb.ToString() + ")";
                    DataRow[] drValidation = dtValidation.Select(tri);
                    if (drValidation.Length == 0) sauver = true;
                }
            }
            return sauver;
        }

		private void AnnuleAdresse()
		{
			txtCodeSiege.Text = string.Empty;
			txtVilleSiege.Text = string.Empty;
			txtCPSiege.Text = string.Empty;
			txtCedexSiege.Text = string.Empty;
			chkCedexSiege.BringToFront();
			chkCedexSiege.Checked = false;
		}

		private void ChangePays()
		{
			if(chkPays.Checked)
			{
				rbAdresseFrance.Checked = true;
				rbAdresseFrance.Font = fontGras;
				rbAdresseEtranger.Font = fontNormal;
			}
			else
			{
				rbAdresseEtranger.Checked = true;
				rbAdresseEtranger.Font = fontGras;
				rbAdresseFrance.Font = fontNormal;
			}
		}

        private void ListerChamps()
        {
            comportement.Champs = new Control[]{txtNom,cmbFJ,dtpOuverture,dtpFermeture,
												   txtCommentairesTigre,txtCommentairesWeb,
												   txtTel,txtFax,txtTel24,txtMel,txtUrl,rbAdresseEtranger,rbAdresseFrance,
												   txtAdr1Siege,txtAdr2Siege,txtCPSiege,txtCedexSiege,chkCedexSiege};
            ChampsSecteur = new Control[] { txtNomSecteur, cmbPRSecteur, txtCommentairesTigreSecteur, txtCommentairesWebSecteur };
        }

		private void RemplisListes()
		{
			if(FBase!=null)
			{
				Cursor = Cursors.WaitCursor;
				FrmDictionnaire fDico = new FrmDictionnaire(FBase);
				fDico.RemplisTypes();
				fDico.GetDico("FormeJuridique");
				fDico.GetDico("TypeIdentifiant");
				fDico = null;
				cmbFJ.DataSource = FBase.TablesDeReference.Tables["FormeJuridique"];
				cmbFJ.DisplayMember = "fjur_libLong";
				cmbFJ.ValueMember = "fjur_codeTerme";
				cmbFJ.SelectedValue = 0;
				cmbTypeIdentifiant.DataSource = FBase.TablesDeReference.Tables["TypeIdentifiant"];
				cmbTypeIdentifiant.DisplayMember = "tidt_libCourt";
				cmbTypeIdentifiant.ValueMember = "tidt_codeTerme";
				cmbTypeIdentifiant.SelectedValue = 0;
				FBase.OterCible(true,false);
				IndiquerFinModif();
				Cursor = Cursors.Default;
			}
		}

		private void RemplisTypes()
		{
			Cursor = Cursors.WaitCursor;
			cmbTypeEnt.Items.AddRange(FBase.ListeTypes);
			OuvrirActivitesDefaut();
			cmbTypeEnt.SelectedIndex = 0;
			Cursor = Cursors.Default;
		}

		private void IndiquerVerification()
		{
			lblEntp.BackColor = Color.Firebrick;
			chkVerifier.Checked = true;
			lblEntp.Text = "Données administratives (à vérifier)";
		}

		private void IndiquerValidation()
		{
			lblEntp.BackColor = Color.OrangeRed;
			chkValider.Checked = true;
            lblEntp.Text = "Données administratives (à valider)";
		}

		private void IndiquerClassement()
		{
			lblEntp.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(115)), ((System.Byte)(189)), ((System.Byte)(31)));
			chkVerifier.Checked = false;
			chkValider.Checked = false;
			chkClasser.Checked = false;
            lblEntp.Text = "Données administratives";
		}

		private void IndiquerInformationNonDIE(string statut, string proprietaire)
		{
			lblEntp.BackColor = Color.Yellow;
			chkVerifier.Checked = false;
			chkValider.Checked = false;
			chkClasser.Checked = false;
            lblEntp.Text = "Données administratives - " + statut + " (données " + proprietaire + ")";
		}

		# endregion

		#region Fonctions publiques et accesseurs

		public MDITigre FBase
		{
			get {return this.comportement.FBase;}
		}

		public int NEntreprise
		{
			get {return this.codeEntreprise;}
		}

		public string Identifiant
		{
			set 
			{
				_modifieID = true;
				txtSIREN.Text = value;
			}
		}

		public int TypeIdentifiant
		{
			set 
			{
				cmbTypeIdentifiant.SelectedValue = value;
			}
		}

		public void Rechercher()
		{
			butRechercher.PerformClick();
		}

		public void Modifier(int code)
		{
			OuvrirEntreprise(code);
            if (PeutValider())
            {
                Text = "Modification des données de l'entreprise";
                mode = ModeFormulaire.Modification;
                Deverrouille();
                IndiquerFinModif();
            }
            else
                Consulter(code, false);
		}

		public void Consulter(int code, bool ouvrir)
		{
			if (ouvrir) OuvrirEntreprise(code);
			Text = "Données de l'entreprise";
			mode = ModeFormulaire.Consultation;
			butRechercher.Visible = false;
			Verrouille();
			IndiquerFinModif();
		}

		public void Fusionner(string de, int siege)
		{
//			txtCode.Text = de;
			codeAdresse = siege;
			if(siege>=0) OuvrirAdresse(Entite.Etablissement);
			comportement.ProcEnregistrement = "p_tigre_fusionentp";
			PeutChanger();
		}

		#endregion

		# region Evènements du formulaire

		private void butID_Click(object sender, System.EventArgs e)
		{
			txtSIREN.ReadOnly = false;
			txtSIREN.BackColor = Color.White;
			cmbTypeIdentifiant.BringToFront();
		}

		private void cmbTypeIdentifiant_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtTypeIdentifiant.Text = cmbTypeIdentifiant.Text;
			ModifieID(sender,e);
		}

		private void butGestionIdentifiant_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(FBase.PeutModifier(1))
				{
					FrmGestionIdentifiant fIdentifiant = new FrmGestionIdentifiant(FBase,Entite.Entreprise,txtSIREN.Text.Trim());
					fIdentifiant.BringToFront();
					fIdentifiant.Show();
				}
			}
			catch 
			{
				MessageBox.Show("Il y a un problème avec cet identifiant ; veuillez contacter le support de l'application",
					"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void butCopieRemarques_Click(object sender, System.EventArgs e)
		{
			if(FBase.PeutModifier(1))
				txtCommentairesWeb.Text = txtCommentairesTigre.Text;
		}

		private void rbAdresseFrance_Click(object sender, System.EventArgs e)
		{
			if(mode!=ModeFormulaire.Consultation)
			{
				chkPays.Checked = true;
				AnnuleAdresse();
				ChangePays();
				ModifieAdresse(sender,e);
			}
		}

		private void rbAdresseEtranger_Click(object sender, System.EventArgs e)
		{
			if(mode!=ModeFormulaire.Consultation)
			{
				chkPays.Checked = false;
				AnnuleAdresse();
				ChangePays();
				ModifieAdresse(sender,e);
			}
		}

		private void cmbTypeEnt_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DialogResult chx = DialogResult.Yes;
			chx = SauvegarderAvant();
			if(chx==DialogResult.Yes)
			{
				int index = cmbTypeEnt.SelectedIndex;
				if(index==0) 
					Monte();
				else
				{
				    DataRow[] drSecteur = FBase.TablesDeReference.Tables["ActiviteSecteur"].Select("asct_activite_fk="+cmbTypeEnt.SelectedIndex);
					if(drSecteur.Length==0)
					{
						bool nouvelle = false;
						panChoixSecteur.Visible = false;
						codeSecteur = ((ComboBoxExItem)cmbTypeEnt.Items[index]).Cle;
						DataRow[] dr = FBase.TablesDeReference.Tables["Activite"].Select("tact_codeTerme="+codeSecteur);
						try
						{
							codeResponsable = Convert.ToInt32(dr[0].ItemArray[12]);
						}
						catch
						{
							codeResponsable = 0;
						}
						nouvelle = MontreDonneesSecteur();
						if(!nouvelle) IndiquerFinModif();
						if(PeutValider()) butModifier.PerformClick();
                        //else comportement.Verrouille(ChampsSecteur);
					}
					else
					{
						Monte();
						this.cmbSecteur.Items.Clear();
						panChoixSecteur.Visible = true;
						this.cmbSecteur.Items.Add(new ComboBoxExItem(0,"--Sélectionnez--",1));
						foreach(DataRow dr in drSecteur)
							this.cmbSecteur.Items.Add(new ComboBoxExItem(Convert.ToInt32(dr.ItemArray[0]),dr.ItemArray[2].ToString(),0));
						OuvrirActiviteSecteur();
						cmbSecteur.SelectedIndex = 0;
					}
					barreSecteur.Visible = !panChoixSecteur.Visible;
				}
			}
		}

		private void cmbSecteur_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DialogResult chx = SauvegarderAvant();
			if(chx==DialogResult.Yes)
			{
				//				if(AChange()) butSauver_Click(sender,e);
				int index = cmbSecteur.SelectedIndex;
				if(index!=0) 
				{
					bool nouvelle = false;
					codeSecteur = ((ComboBoxExItem)cmbSecteur.Items[index]).Cle;
					DataRow[] dr = FBase.TablesDeReference.Tables["ActiviteSecteur"].Select("tact_codeTerme="+codeSecteur);
					try
					{
						codeResponsable = Convert.ToInt32(dr[0].ItemArray[12]);
					}
					catch
					{
						codeResponsable = 0;
					}
					nouvelle = MontreDonneesSecteur();
//					if(FBase.AProfil(1)) butModifier.PerformClick();
//					else if(!nouvelle) IndiquerFinModif();
					if(!nouvelle) IndiquerFinModif();
				}
			}
		}

		private void butDicoFJ_Click(object sender, System.EventArgs e)
		{
			if(FBase.PeutModifier(1))
			{
				Control[] cibles = {butMajCmbFJ,cmbFJ};
				object[] comm = {5,0};
				FBase.CreerCible(this,cibles,comm);
				object[] recherches = DicoDeRecherche((Control)sender);
				FBase.MontreDico(Convert.ToInt32(recherches[0]),recherches[1].ToString(),cmbFJ.Text);
			}
		}

		private void MajCmbFJ(object sender, System.EventArgs e)
		{
			cmbFJ.DataSource = FBase.TablesDeReference.Tables["FormeJuridique"];
			cmbFJ.SelectedValue = 0;
		}

		private void butCommunication_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
				{
					FrmCommunication fCommunication = new FrmCommunication(this.FBase);
					fCommunication.OuvrirSur(codeEntreprise,ModeCommunication.NonAdresse,Entite.Entreprise);
					fCommunication.Show();
				}
			}
		}

		private void butAdresse_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
				{
					FrmCommunication fCommunication = new FrmCommunication(this.FBase);
					fCommunication.OuvrirSur(codeEntreprise,ModeCommunication.Adresse,Entite.Entreprise);
					fCommunication.Show();
				}
			}
		}

		private void butCompletion_Click(object sender, System.EventArgs e)
		{
			if(FBase.PeutModifier(1))
			{
				FBase.AideSaisieVille(this,txtCPSiege,txtCodeSiege,txtVilleSiege,rbAdresseFrance.Checked);
				ModifieAdresse(sender,e);
			}
		}

//		private void txtCPSiege_TextChanged(object sender, System.EventArgs e)
//		{
//			if(!txtCPSiege.Focused)
//			{
//				AnnuleAdresse();
//			}
//		}
//
		private void txtCPSiege_Enter(object sender, System.EventArgs e)
		{
			if((FBase.AProfil(1))&&(!txtCPSiege.ReadOnly)) AnnuleAdresse();
		}

		private void chkCedexSiege_CheckedChanged(object sender, System.EventArgs e)
		{
			if((FBase.PeutModifier(1))&&(!txtCPSiege.ReadOnly))
			{
				if(chkCedexSiege.Checked) chkCedexSiege.SendToBack();
				else chkCedexSiege.BringToFront();
				ModifieAdresse(sender,e);
			}
		}

		private void txtCedexSiege_TextChanged(object sender, System.EventArgs e)
		{
			if(FBase.PeutModifier(1)) ModifieAdresse(sender,e);
		}

		private void butHistorique_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				butMetier.BringToFront();
				panHistorique.Left = 56;
				panHistorique.BringToFront();
				cmbHistorique_SelectedIndexChanged(this,EventArgs.Empty);
			}
		}

		private void butMetier_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				butHistorique.BringToFront();
				panHistorique.Left = 1000;
			}
		}

		private void butEtablissement_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
				{
					FrmListeEtablissements fEtablissements = new FrmListeEtablissements(this.FBase);
					fEtablissements.OuvrirSur(codeEntreprise);
					fEtablissements.Show();
				}
			}
		}

		private void butSousTraitant_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
				{
					FrmAnnexeMetier fMetier = new FrmAnnexeMetier(this.FBase);
					fMetier.OuvrirSur(Entite.Entreprise,codeEntreprise,TypeActivite.Neutre);
					fMetier.Show();
				}
			}
		}

		private void butResponsable_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
				{
					FrmResponsable fResponsable = new FrmResponsable(this.FBase);
					fResponsable.OuvrirSur(Entite.Entreprise,codeEntreprise,TypeActivite.Neutre);
					fResponsable.Show();
				}
			}
		}

		private void butNouveau_Click(object sender, System.EventArgs e)
		{
			if(FBase.PeutModifier(1))
			{
				if(AChange())
				{
					DialogResult choix = comportement.SontDonneesSauvees();
					switch(choix)
					{
						case DialogResult.Yes:
							butSauver.PerformClick();
							break;
						case DialogResult.No:
							break;
						case DialogResult.Cancel:
							return;
					}
				}
				butFermer.PerformClick();
				FBase.CreerEntreprise();
			}
		}

		private void butModifier_Click(object sender, System.EventArgs e)
		{
            if (!PeutValider())
                MessageBox.Show("Vos droits ne vous permettent pas de modifier ces données",
                    "TIGRE", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (FBase.PeutModifier(1))
            {
                Deverrouille();
                Text = "Modification d'entreprise";
            }
        }

		private void butRechercher_Click(object sender, System.EventArgs e)
		{
			DialogResult chx = SauvegarderAvant();
			if(chx==DialogResult.Yes)
				FBase.ChercherEntreprise();
		}

        private void butSauver_Click(object sender, System.EventArgs e)
        {
            if (AChange())
            {
                if (PeutValider())
                    SauverSecteur();
                else
                    MessageBox.Show("Vos droits ne vous permettent pas de modifier les données de cette entreprise",
                            "TIGRE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (codeEntreprise != 0)
            {
                Form fSuivant = FBase.FPrecedent;
                if (fSuivant is FrmEntpFusion)
                {
                    try
                    {
                        DataTable dt = FBase.EnvoyerProcedure("p_tigre_absorption", ((FrmEntpFusion)fSuivant).CodeA + "," + codeEntreprise);
                        int ta = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                        dt = FBase.EnvoyerProcedure("p_tigre_absorption", ((FrmEntpFusion)fSuivant).CodeB + "," + codeEntreprise);
                        ta += Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                        if (ta > 0)
                            MessageBox.Show("L'entreprise vient d'acquérir " + ta + " activité(s)", "TIGRE",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Fusion réalisée", "TIGRE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Problème lors de la fusion :\n" + exc.Message, "TIGRE",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Verrouille();
                this.Text = "Données de l'entreprise";
                OuvrirEntreprise(codeEntreprise);
            }
        }

		private void butSupprimer_Click(object sender, System.EventArgs e)
		{
			if(!PeutValider())
				MessageBox.Show("Vos droits ne vous permettent pas de supprimer ces données",
					"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Stop);
			else if(FBase.PeutModifier(1))
			{
				if(codeEntreprise==0) 
					MessageBox.Show("Vous devez sélectionner une entreprise","TIGRE",
						MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				else
				{
					DialogResult chx = MessageBox.Show("Etes-vous sûr de vouloir supprimer entreprise?\nToutes ses activités seront perdues",
						"TIGRE",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
					DataTable dtSuppression = FBase.EnvoyerProcedure(comportement.ProcSuppression,(int)TypeActivite.Neutre+","+codeEntreprise+",1");
					switch(Convert.ToInt32(dtSuppression.Rows[0].ItemArray[0]))
					{
						case 0:
							MessageBox.Show("Entreprise supprimée","TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Information);
							butFermer.PerformClick();
							break;
						case -1:
							MessageBox.Show("Cette entreprise possède des établissements que vous ne pouvez supprimer ; suppression annulée",
								"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Stop);
							break;
						default:
							chx = MessageBox.Show("Cette entreprise possède des établissements, et/ou a fait l'objet de dossiers ; confirmez-vous la suppression ? (toutes ses données seront perdues)",
								"TIGRE",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
							if(chx==DialogResult.Yes)
							{
								FBase.EnvoyerProcedure(comportement.ProcSuppression,(int)TypeActivite.Neutre+","+codeEntreprise+",0");
								MessageBox.Show("Entreprise supprimée","TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Information);
								butFermer.PerformClick();
							}
							break;
					}
				}
			}
		}

		private void butImprimer_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
                TypeActivite activite = (TypeActivite)Convert.ToInt32(((ComboBoxExItem)(cmbTypeEnt.SelectedItem)).Cle);
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
					FBase.EditerEntreprise(codeEntreprise,activite);
			}
		}

		private void butMessage_Click(object sender, System.EventArgs e)
		{
			if((codeEntreprise==0)&&!AChange())
				MessageBox.Show("Vous devez d'abord enregistrer ou sélectionner une entreprise","TIGRE",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
			else
			{
				DialogResult chx = SauvegarderAvant();
				if(chx==DialogResult.Yes)
					FBase.EcrireMessage(txtNom.Text,new object[]{1,codeEntreprise,0});
			}
		}

		private void butFermer_Click(object sender, System.EventArgs e)
		{
			Form fSuivant = FBase.FPrecedent;
			if(AChange())
			{
				DialogResult chx = MessageBox.Show("Voulez-vous enregistrer les modifications","TIGRE",
					MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				if(chx==DialogResult.Yes) butSauver.PerformClick();
				else if(chx==DialogResult.Cancel) return;
			}
			if(fSuivant is IRechercheEntreprise)
				((IRechercheEntreprise)fSuivant).OuvrirEntreprise(codeEntreprise);
//			else if(fSuivant is FrmDossier)
//				((FrmDossier)fSuivant).OuvrirEntreprise(codeEntreprise);
//			else if(fSuivant is FrmEntpAbsorption)
//				((FrmEntpAbsorption)fSuivant).OuvrirEntreprise(codeEntreprise);
//			else if(fSuivant is FrmEntpFusion)
//				((FrmEntpFusion)fSuivant).OuvrirEntreprise(codeEntreprise);
//			else if(fSuivant is FrmEtabTransfert)
//				((FrmEtabTransfert)fSuivant).OuvrirEntreprise(codeEntreprise);
			Fermer(true,true);
		}

		private void dtpOuverture_Leave(object sender, System.EventArgs e)
		{
			if(dtpOuverture.Checked) txtDtpOuverture.Text = dtpOuverture.Value.ToShortDateString();
			else txtDtpOuverture.Text = "";
			Modifie(sender,e);
		}

		private void dtpFermeture_Leave(object sender, System.EventArgs e)
		{
			if(dtpFermeture.Checked) txtDtpFermeture.Text = dtpFermeture.Value.ToShortDateString();
			else txtDtpFermeture.Text = "";
			Modifie(sender,e);
		}

		private void Modifie(object sender, System.EventArgs e)
		{
			this._modifie = true;
		}

		private void ModifieID(object sender, System.EventArgs e)
		{
			this._modifieID = true;
		}

		private void ModifieAdresse(object sender, System.EventArgs e)
		{
			this._modifieAdresse = true;
		}

		private void ModifieCommunication(object sender, System.EventArgs e)
		{
			this._modifieComm = true;
		}

		private void chkVerifier_Click(object sender, System.EventArgs e)
		{
			if(chkVerifier.Checked)
			{
				if((PeutValider())&&(FBase.TablesDeReference.Tables["Validation"].Select("dvut_statut_fk=3").Length>0))
				{
					IndiquerVerification();
					FBase.EcrireMessage(txtNom.Text,new object[]{1,codeEntreprise,3});
				}
				else
				{
					chkVerifier.Checked = false;
					MessageBox.Show("Vos droits ne vous permettent pas d'indiquer ces données comme à vérifier par la DIE",
						"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				}
			}
			else
			{
				chkVerifier.Checked = true;
				FBase.ConsulterMessage(messageStatut[0]);
			}
		}

		private void chkValider_Click(object sender, System.EventArgs e)
		{
			if(chkValider.Checked)
			{
				if((PeutValider())&&(FBase.TablesDeReference.Tables["Validation"].Select("dvut_statut_fk=2").Length>0))
				{
					IndiquerValidation();
					FBase.EcrireMessage(txtNom.Text,new object[]{1,codeEntreprise,2});
				}
				else
				{
					chkValider.Checked = false;
					MessageBox.Show("Vos droits ne vous permettent pas d'indiquer ces données comme à valider par la DIE",
						"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				}
			}
			else
			{
				chkValider.Checked = true;
				FBase.ConsulterMessage(messageStatut[1]);
			}
		}

		private void chkClasser_Click(object sender, System.EventArgs e)
		{
		
			if((PeutValider())&&(FBase.TablesDeReference.Tables["Validation"].Select("dvut_statut_fk=1").Length>0))
			{
				IndiquerClassement();
				FBase.EcrireMessage(txtNom.Text,new object[]{1,codeEntreprise,1});
			}
			else
			{
				chkClasser.Checked = false;
				MessageBox.Show("Vos droits ne vous permettent pas d'indiquer ces données comme à classer (validées) par la DIE",
					"TIGRE",MessageBoxButtons.OK,MessageBoxIcon.Stop);
			}
		}

        private void lblEntp_BackColorChanged(object sender, EventArgs e)
        {
            lblMetier.BackColor = lblEntp.BackColor;
        }

		#endregion

		# region Evènements des panels données métier

		private void ModifieSecteur(object sender, System.EventArgs e)
		{
			this._modifieSecteur = true;
		}

		private void ModifiePRSecteur(object sender, System.EventArgs e)
		{
            if (codeResponsable == 0)
            {
                MessageBox.Show("Vous ne pouvez pas modifier cette information", "TIGRE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomSecteur.Focus();
            }
            else
                ModifieSecteur(sender, e);
		}

		private void butResponsableSecteur_Click(object sender, System.EventArgs e)
		{
			butResponsable_Click(sender,e);
		}

		private void butEtablissementSecteur_Click(object sender, System.EventArgs e)
		{
			butEtablissement_Click(sender,e);
		}

		private void butSousTraitantSecteur_Click(object sender, System.EventArgs e)
		{
			butSousTraitant_Click(sender,e);
		}

		private void butDicoPersonne_Click(object sender, System.EventArgs e)
		{
            _modifieSecteur = true;
			if(FBase.PeutModifier(1))
			{
				Control[] cibles = {butMajCmbPR,cmbPRSecteur};
				object[] comm = {5,0};
				FBase.CreerCible(cibles,comm);
				object[] recherches = DicoDeRecherche((Control)sender);
				FBase.MontreDico(Convert.ToInt32(recherches[0]),recherches[1].ToString(),cmbPRSecteur.Text);
			}
		}

		private void MajCmbPR(object sender, System.EventArgs e)
		{
			cmbPRSecteur.DataSource = FBase.TablesDeReference.Tables["Personne"].Copy();
			cmbPRSecteur.SelectedValue = 0;
		}

		private void butSupprimerSecteur_Click(object sender, System.EventArgs e)
		{
			SupprimerSecteur();
		}

		private void butCommentairesTigreSecteur_Click(object sender, System.EventArgs e)
		{
			panCommentairesWebSecteur.Left = 1000;
			panTabCommentaireSecteur.Top = 128;
		}

		private void butCommentairesWebSecteur_Click(object sender, System.EventArgs e)
		{
			panCommentairesWebSecteur.Left = 136;
			panTabCommentaireSecteur.Top = 160;
		}

		private void butCopieRemarquesSecteur_Click(object sender, System.EventArgs e)
		{
			if(FBase.PeutModifier(1))
			{
				txtCommentairesWebSecteur.Text = txtCommentairesTigreSecteur.Text;
				ModifieSecteur(sender,e);
			}
		}

		private void txtEtatSecteur_TextChanged(object sender, System.EventArgs e)
		{
			switch(txtEtatSecteur.Text)
			{
				case "1":
					lblEtatSecteur.Text = "OUVERTE";
					lblEtatSecteur.BackColor = Color.Lime;
					break;
				case "-1":
					lblEtatSecteur.Text = "FERMEE";
					lblEtatSecteur.BackColor = Color.Red;
					break;
				default:
					lblEtatSecteur.Text ="";
					lblEtatSecteur.BackColor = this.BackColor;
					break;
			}
		}

		#endregion

		#region Evènements du panel historique

		private void cmbHistorique_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string[] lesEntetes = new string[]{"Donnée","","Utilisé jusqu'au"};
			int[] lesLargeurs = new int[]{400,100,100};
			dtHistorique = FBase.EnvoyerProcedure("p_tigre_ouvreHistorique",(int)Entite.Entreprise+","+codeEntreprise+","+cmbHistorique.SelectedIndex);
			dagHistorique.TableStyles.Clear();
			DataView dvHistorique = new DataView(dtHistorique,"","histo_date desc",DataViewRowState.CurrentRows);
			switch(cmbHistorique.SelectedIndex)
			{
				case 0:
					lesEntetes = new string[]{"Nom","Pour l'activité","Utilisé jusqu'au"};
					lesLargeurs = new int[]{490,195,107};
					lblHistoriqueZoom.Visible = false;
					break;
				case 1:
					lesEntetes = new string[]{"Ville et pays","Type d'adresse","Utilisée jusqu'au","",""};
					lesLargeurs = new int[]{340,345,107,0,0};
					lblHistoriqueZoom.Visible = true;
					break;
				case 2:
					lesEntetes = new string[]{"Identifiant","Type","Utilisé jusqu'au"};
					lesLargeurs = new int[]{490,195,107};
					lblHistoriqueZoom.Visible = false;
					break;
				case 3:
					lesEntetes = new string[]{"Nom","Type de responsabilité","Actif jusqu'au",""};
					lesLargeurs = new int[]{340,345,107,0};
					lblHistoriqueZoom.Visible = true;
					break;
			}
			int[] indexcle = {1};
			int[] indexchamp = {1};
			DataTable dt = CFormulaireTigre.DistinctRow(dtHistorique,indexchamp,indexcle);
			this.cmbFiltre.SelectedIndexChanged -= new System.EventHandler(this.cmbFiltre_SelectedIndexChanged);
			DataRow dr = dt.NewRow();
			dr["histo_filtre"] = "(Aucun)";
			dt.Rows.InsertAt(dr,0);
			cmbFiltre.DisplayMember = "histo_filtre";
			cmbFiltre.DataSource = dt;
			this.cmbFiltre.SelectedIndexChanged += new System.EventHandler(this.cmbFiltre_SelectedIndexChanged);
			DataGridTableStyle dgts = comportement.CreerTabStyle(dvHistorique,lesEntetes,lesLargeurs);
			dagHistorique.TableStyles.Add(dgts);
			dagHistorique.DataSource = dvHistorique;
			panHistoriqueZoom.Left = 1000;
		}

		private void cmbFiltre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataView dvHistorique;
			if(cmbFiltre.SelectedIndex>0) 
				dvHistorique = new DataView(dtHistorique,"histo_filtre='"+cmbFiltre.Text+"'","histo_date desc",DataViewRowState.CurrentRows);
			else
				dvHistorique = new DataView(dtHistorique,"","histo_date desc",DataViewRowState.CurrentRows);
			dagHistorique.DataSource = dvHistorique;
		}

		private void dagHistorique_Click(object sender, System.EventArgs e)
		{
			StringBuilder sb;
			switch(cmbHistorique.SelectedIndex)
			{
				case 1:
					sb = new StringBuilder(dagHistorique[dagHistorique.CurrentRowIndex,3].ToString()+"\r\n");
					sb.Append(dagHistorique[dagHistorique.CurrentRowIndex,0].ToString()+"\r\n");
					sb.Append(dagHistorique[dagHistorique.CurrentRowIndex,4].ToString());
					txtHistoriqueZoom.Text = sb.ToString();
					panHistoriqueZoom.Left = 24;
					panHistoriqueZoom.BringToFront();
					break;
				case 3:
					sb = new StringBuilder(dagHistorique[dagHistorique.CurrentRowIndex,0].ToString()+"\r\n");
					sb.Append(dagHistorique[dagHistorique.CurrentRowIndex,3].ToString());
					txtHistoriqueZoom.Text = sb.ToString();
					panHistoriqueZoom.Left = 24;
					panHistoriqueZoom.BringToFront();
					break;
			}
		}

		private void butHistoriqueZoom_Click(object sender, System.EventArgs e)
		{
			panHistoriqueZoom.Left = 1000;
		}

		#endregion

	}
}