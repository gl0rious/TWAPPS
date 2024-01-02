using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TWOra;

namespace twAdmin {
    public partial class UnblockForm : Form {
        Database db;
        public UnblockForm(Database db) {
            InitializeComponent();
            this.db = db;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void UnblockForm_Load(object sender, EventArgs e) {
            displayBlockingSessions();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            displayBlockingSessions();
        }

        private void displayBlockingSessions() {
            tvSessions.Nodes.Clear();
            var allSessions = Session.AllSessions(db);
            List<TreeNode> nodes = new List<TreeNode>();

            foreach(var session in allSessions) {
                if(session.BlockingSession != null) {
                    var blockingSession = allSessions.Find(s => s.SID == session.BlockingSession);
                    if(blockingSession == null)
                        continue;

                    var node = nodes.Find(n => (n.Tag as Session).SID == session.SID);
                    if(node == null) {
                        node = new TreeNode($"{session.Username} [{session.SID}]");
                        node.Tag = session;
                        nodes.Add(node);
                    }
                    var blockingNode = nodes.Find(n => (n.Tag as Session).SID == blockingSession.SID);
                    if(blockingNode == null) {
                        blockingNode = new TreeNode($"{blockingSession.Username} [{blockingSession.SID}");
                        blockingNode.Tag = blockingSession;
                        nodes.Add(blockingNode);
                    }
                    blockingNode.Nodes.Add(node);
                }
            }
            foreach(var node in nodes) {
                if(node.Parent == null) {
                    tvSessions.Nodes.Add(node);
                }
            }
            tvSessions.ExpandAll();
        }

        private void btnUnblock_Click(object sender, EventArgs e) {
            var allSessions = Session.AllSessions(db);
            List<Session> topBlockingSessions = new List<Session>();
            foreach(var session in allSessions) {
                if(session.BlockingSession != null) {
                    var sess = session;
                    while(sess.BlockingSession != null)
                        sess = allSessions.Find(s => s.SID == sess.BlockingSession);
                    if(!topBlockingSessions.Contains(sess))
                        topBlockingSessions.Add(sess);
                }
            }
            foreach(var session in topBlockingSessions)
                session.Terminate();
            displayBlockingSessions();
        }
    }
}
